using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeaderboardRow : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI scoreText;

        public void Setup(LeaderboardEntry entry, bool isCurrentPlayer)
        {
            nameText.text = entry.playerName;
            scoreText.text = entry.score.ToString() ;

        }
    }
}