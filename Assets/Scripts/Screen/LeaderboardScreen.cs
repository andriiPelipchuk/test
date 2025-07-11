using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Screen
{
    public class LeaderboardScreen : MonoBehaviour
    {
        public Transform content;        
        public GameObject row;     

        public TextMeshProUGUI playerName;
        public TextMeshProUGUI playerScore;
        public GameObject stars;

        private void Start()
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            var currentPlayerName = PlayerPrefsManager.GetNickname();
            var currentScore = PlayerPrefsManager.GetPlayerScore();

            playerName.text = currentPlayerName;
            playerScore.text = currentScore.ToString();

            List<LeaderboardEntry> all = GenerateMockLeaderboard();

            all.RemoveAll(e => e.playerName == currentPlayerName);

            foreach (Transform child in content)
                Destroy(child.gameObject);

            foreach (var entry in all)
            {
                var obj = Instantiate(this.row, content);
                var row = obj.GetComponent<LeaderboardRow>();
                row.Setup(entry, false);
            }
        }

        private List<LeaderboardEntry> GenerateMockLeaderboard()
        {
            return new List<LeaderboardEntry>
        {
            new LeaderboardEntry(PlayerPrefsManager.GetNickname(), PlayerPrefsManager.GetPlayerScore()),
            new LeaderboardEntry("Anna", 12500),
            new LeaderboardEntry("Evgen", 9300),
            new LeaderboardEntry("Illya", 8500),
            new LeaderboardEntry("Maria", 7200)
        };
        }
    }
}