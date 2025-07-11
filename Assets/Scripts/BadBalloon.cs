using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class BadBalloon : MonoBehaviour
    {

        public int score = -10;
        private int _timeToDestroy = 2;
        private void Start()
        {
            StartCoroutine(TimeToDestroy());
        }
        public void Pop()
        {
            var balloonGame = FindObjectOfType<BalloonGame>();
            balloonGame.UpdateScoreUI(score);
            Destroy(gameObject);
        }

        IEnumerator TimeToDestroy()
        {
            yield return new WaitForSeconds(_timeToDestroy);
            Destroy(gameObject);
        }
    }
}