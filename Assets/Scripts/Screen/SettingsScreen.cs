using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Screen
{
    public class SettingsScreen : MonoBehaviour
    {
        public Slider sound;
        public Slider music;

        public Button soundReduceButton;
        public Button soundIncreaseButton;

        public Button musicReduceButton;
        public Button musicIncreaseButton;

        public Button save;

        private bool _firstLaunch = true;
        private float _defaultVolume = 1;

        private void Start()
        {
            if (_firstLaunch)
            {
                _firstLaunch = false;
                PlayerPrefsManager.SetSoundVolume(_defaultVolume);
                PlayerPrefsManager.SetMusicVolume(_defaultVolume);
                PlayerPrefsManager.SaveAll();
            }

            soundReduceButton.onClick.AddListener(() => AdjustSlider(sound, -0.1f));
            soundIncreaseButton.onClick.AddListener(() => AdjustSlider(sound, 0.1f));

            musicReduceButton.onClick.AddListener(() => AdjustSlider(music, -0.1f));
            musicIncreaseButton.onClick.AddListener(() => AdjustSlider(music, 0.1f));

            LoadSettings();

            save.onClick.AddListener(SaveSettings);
        }
        private void AdjustSlider(Slider slider, float delta)
        {
            slider.value = Mathf.Clamp01(slider.value + delta);
            if (slider == sound)
            {
                PlayerPrefsManager.SetSoundVolume(slider.value);
            }
            else if (slider == music)
            {
                PlayerPrefsManager.SetMusicVolume(slider.value);
            }
        }

        private void LoadSettings()
        {
            sound.value = PlayerPrefsManager.GetSoundVolume();
            music.value = PlayerPrefsManager.GetMusicVolume();
        }

        private void SaveSettings()
        {
            PlayerPrefsManager.SetSoundVolume(sound.value);
            PlayerPrefsManager.SetMusicVolume(music.value);
            PlayerPrefsManager.SaveAll();
        }
    }
}