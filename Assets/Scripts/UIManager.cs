using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public GameObject menuPanel;
        public GameObject settingsPanel;
        public GameObject accountPanel;
        public GameObject shopPanel;
        public GameObject levelsPanel;
        public GameObject leaderboardPanel;
        public GameObject tutorialPanel;

        public int currentLevel;
        public bool _isTutorialAccepted = false;
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
        public void ShowScreen(GameObject screen)
        {
            if(screen == levelsPanel && !_isTutorialAccepted)
            {
                _isTutorialAccepted = true;
                HideAllScreens();
                screen = tutorialPanel;
                screen.SetActive(true);
            }
            else
            {
                HideAllScreens();
                screen.SetActive(true);
            }
                
        }

        public void HideAllScreens()
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            accountPanel.SetActive(false);
            shopPanel.SetActive(false);
            levelsPanel.SetActive(false);
            leaderboardPanel.SetActive(false);
            tutorialPanel.SetActive(false);
        }

        public void ShowMenu() => ShowScreen(menuPanel);
        public void ShowSettings() => ShowScreen(settingsPanel);

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
