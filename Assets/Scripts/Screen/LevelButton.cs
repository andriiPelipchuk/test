using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Screen
{
    public class LevelButton : MonoBehaviour
    {
        public int levelNumber;
        public Button button;
        public TextMeshProUGUI levelNumberText;
        public GameObject lockIcon;
        public Image[] stars;

        public void Setup(int level, bool isUnlocked, int starCount)
        {
            levelNumber = level;
            levelNumberText.text = level.ToString();
            lockIcon.SetActive(!isUnlocked);
            button.interactable = isUnlocked;

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].enabled = i < starCount;
            }

            button.onClick.RemoveAllListeners();
            if (isUnlocked)
            {
                button.onClick.AddListener(() => StartLevel(level));
            }
        }

        private void StartLevel(int level)
        {
            UIManager.Instance.HideAllScreens();
            UIManager.Instance.currentLevel = level;
            SceneManager.LoadScene("GameScene");
        }
    }
}