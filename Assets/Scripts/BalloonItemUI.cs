using Assets.Scripts.Screen;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class BalloonItemUI : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI buttonText;
        public Button actionButton;

        private BalloonItemData data;

        public BuyPopupUI buyPopup;

        public void Setup(BalloonItemData itemData)
        {
            data = itemData;

            icon.sprite = data.sprite;

            string selectedId = PlayerPrefsManager.GetSelectedBalloon();
            bool isOwned = PlayerPrefsManager.IsBalloonOwned(data.id);

            actionButton.onClick.RemoveAllListeners();

            if (selectedId == data.id)
            {
                buttonText.text = "SELECTED";
                actionButton.interactable = false;
            }
            else if (isOwned)
            {
                buttonText.text = "SELECT";
                actionButton.onClick.AddListener(() => SelectBalloon());
            }
            else
            {
                buttonText.text = data.price.ToString();
                actionButton.onClick.AddListener(() => buyPopup.Show(data));
            }
        }

        private void SelectBalloon()
        {
            PlayerPrefsManager.SetSelectedBalloon(data.id);
            FindObjectOfType<ShopScreen>().ReloadShop();
        }
    }
}