using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

namespace Assets.Scripts.Screen
{
    public class ShopScreen : MonoBehaviour
    {
        public Transform itemsContainer;
        public GameObject balloonItemPrefab;

        public Button leftButton;
        public Button rightButton;
        public TextMeshProUGUI balanceText;
        public BuyPopupUI buyPopupRef;

        public List<BalloonItemData> allItems;
        private int currentPage = 0;
        private const int itemsPerPage = 4;

        private void Start()
        {
            buyPopupRef.Init(this); 

            leftButton.onClick.AddListener(PrevPage);
            rightButton.onClick.AddListener(NextPage);

            LoadShopPage();
            UpdateBalanceUI();
        }

        public void LoadShopPage()
        {
            foreach (Transform child in itemsContainer)
                Destroy(child.gameObject);

            int start = currentPage * itemsPerPage;

            for (int i = 0; i < itemsPerPage; i++)
            {
                int index = start + i;
                if (index >= allItems.Count) break;

                var itemData = allItems[index];

                GameObject obj = Instantiate(balloonItemPrefab, itemsContainer);
                var itemUI = obj.GetComponent<BalloonItemUI>();
                itemUI.buyPopup = buyPopupRef;
                itemUI.Setup(itemData); 
            }

            leftButton.interactable = currentPage > 0;
            rightButton.interactable = (currentPage + 1) * itemsPerPage < allItems.Count;
        }
        public void ReloadShop()
        {
            UpdateBalanceUI();
            LoadShopPage();
        }

        private void PrevPage()
        {
            currentPage--;
            LoadShopPage();
        }

        private void NextPage()
        {
            currentPage++;
            LoadShopPage();
        }

        public void UpdateBalanceUI()
        {
            balanceText.text = PlayerPrefsManager.GetCoins().ToString("N0");
        }
    }
}