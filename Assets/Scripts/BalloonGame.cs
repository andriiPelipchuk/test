using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class BalloonGame : MonoBehaviour
    {
        public GameObject balloon;
        public GameObject badBalloonPrefab;
        public float spawnRate = 1f;
        public float minSpeed = 1f;
        public float maxSpeed = 3f;
        public int score = 0;
        public TextMeshProUGUI scoreText;
        public int value = 60, iteration = 0;

        private bool isGameOver = false;
        private float nextSpawnTime;

        private void Start()
        {
            nextSpawnTime = Time.time + spawnRate;
            UpdateScoreUI(0);
        }

        void Update()
        {
            if (Time.time >= nextSpawnTime && !isGameOver)
            {
                SpawnBalloon();
                nextSpawnTime = Time.time + spawnRate;
            }
        }
        public void OpenMenu()
        {

            SceneManager.LoadScene("MenuScene");
        }
        private void SpawnBalloon()
        {
            if (iteration >= value)
            {
                isGameOver = true;
                UIManager.Instance.ShowScreen(UIManager.Instance.leaderboardPanel);
                PlayerPrefsManager.SetCoins(PlayerPrefsManager.GetCoins() + score);
                PlayerPrefsManager.UnlockLevel(UIManager.Instance.currentLevel + 1);
                PlayerPrefsManager.SaveAll();
                OpenMenu();
            }
            var isPopBalloon = UnityEngine.Random.Range(0f, 1f) > 0.3f;
            var balloonPrefab = isPopBalloon ? this.balloon : badBalloonPrefab;
            Vector2 spawnPos = GetRandomPositionWithinScreen();
            var balloon = Instantiate(balloonPrefab, spawnPos, Quaternion.identity, transform);
            iteration++;

        }

        private Vector2 GetRandomPositionWithinScreen()
        {
            Vector2 screenMin = Vector2.zero;
            Vector2 screenMax = new Vector2(UnityEngine.Screen.width, UnityEngine.Screen.height);

            return new Vector2(Random.Range(screenMin.x, screenMax.x), Random.Range(screenMin.y, screenMax.y));
        }
        public void UpdateScoreUI(int scoreValue)
        {
            if (scoreText != null)
            {
                score += scoreValue;
                PlayerPrefsManager.SetPlayerScore(PlayerPrefsManager.GetPlayerScore() + score);

                scoreText.text = "Score: " + score;
            }
        }
        public void ReturnToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}