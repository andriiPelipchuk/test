using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Image progressImage;
        private string _nextSceneName = "MenuScene";

        private void Start()
        {
            StartCoroutine(LoadAsync());
        }

        private IEnumerator LoadAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_nextSceneName);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                UpdateUI(progress);

                if (progress >= 1f)
                {
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        private void UpdateUI(float progress)
        {
            if (progressImage != null)
                progressImage.fillAmount = progress;
        }
    }
}