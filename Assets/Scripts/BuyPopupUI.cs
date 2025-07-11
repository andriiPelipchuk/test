using Assets.Scripts.Screen;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class BuyPopupUI : MonoBehaviour
    {
        public Image balloonImage;
        public Button buyButton;
        public Button cancelButton;

        private BalloonItemData currentItem;

        private ShopScreen shopScreen;

        public void Init(ShopScreen shop)
        {
            shopScreen = shop;
            buyButton.onClick.AddListener(OnBuy);
            cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void Show(BalloonItemData item)
        {
            currentItem = item;
            balloonImage.sprite = item.sprite;
            gameObject.SetActive(true);
        }

        private void OnBuy()
        {
            int balance = PlayerPrefsManager.GetCoins();

            if (balance >= currentItem.price)
            {
                PlayerPrefsManager.SetCoins(balance - currentItem.price);
                PlayerPrefsManager.MarkBalloonOwned(currentItem.id);
                PlayerPrefsManager.SetSelectedBalloon(currentItem.id);
            }

            gameObject.SetActive(false);
            shopScreen.ReloadShop();
        }
    }
}