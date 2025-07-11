using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class LeaderboardEntry : MonoBehaviour
    {
        public string playerName;
        public int score;

        public LeaderboardEntry(string name, int score)
        {
            this.playerName = name;
            this.score = score;
        }
    }
}