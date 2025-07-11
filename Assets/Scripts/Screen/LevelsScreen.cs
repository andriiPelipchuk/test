using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Screen
{
    public class LevelsScreen : MonoBehaviour
    {
        public Transform contentParent;
        public GameObject levelButtonPrefab;
        public int totalLevels = 20;

        private void Start()
        {
            GenerateLevelButtons();
        }

        private void GenerateLevelButtons()
        {
            for (int i = 1; i <= totalLevels; i++)
            {
                var obj = Instantiate(levelButtonPrefab, contentParent);
                var button = obj.GetComponent<LevelButton>();

                var unlocked = PlayerPrefsManager.IsLevelUnlocked(i);
                var stars = PlayerPrefs.GetInt($"LevelStars_{i}", 0);

                button.Setup(i, unlocked, stars);
            }
        }
    }
}