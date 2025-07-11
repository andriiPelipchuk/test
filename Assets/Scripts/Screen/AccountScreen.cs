using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Screen
{
    public class AccountScreen : MonoBehaviour
    {
        public Image avatar;
        public TMP_InputField nameInput;
        public TextMeshProUGUI nickname;
        public Button save;
        public Button backToMenu;

        public Sprite[] availableAvatars; 
        private int _currentAvatarIndex = 0;

        private void Start()
        {
            LoadAccount();

            save.onClick.AddListener(SaveAccount);
            backToMenu.onClick.AddListener(() => UIManager.Instance.ShowMenu());

            var avatarBtn = avatar.GetComponent<Button>();
            if (avatarBtn != null)
                avatarBtn.onClick.AddListener(SwitchAvatar);
        }

        private void LoadAccount()
        {
            nickname.text = PlayerPrefsManager.GetNickname();

            string savedAvatar = PlayerPrefsManager.GetAvatar();
            for (int i = 0; i < availableAvatars.Length; i++)
            {
                if (availableAvatars[i].name == savedAvatar)
                {
                    _currentAvatarIndex = i;
                    break;
                }
            }
            avatar.sprite = availableAvatars[_currentAvatarIndex];
        }

        private void SaveAccount()
        {
            if(!string.IsNullOrWhiteSpace(nameInput.text))
            {
                PlayerPrefsManager.SetNickname(nameInput.text);
            }
            PlayerPrefsManager.SetAvatar(availableAvatars[_currentAvatarIndex].name);
            PlayerPrefsManager.SaveAll();

            nickname.text = PlayerPrefsManager.GetNickname();
            string savedAvatar = PlayerPrefsManager.GetAvatar();
        }

        private void SwitchAvatar()
        {
            _currentAvatarIndex = (_currentAvatarIndex + 1) % availableAvatars.Length;
            avatar.sprite = availableAvatars[_currentAvatarIndex];
        }
    }
}