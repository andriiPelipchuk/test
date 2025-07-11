using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class PlayerPrefsManager
    {
        private const string _soundVolumeKey = "SoundVolume";
        private const string _musicVolumeKey = "MusicVolume";
        private const string _notificationKey = "Notification"; 

        private const string _nicknameKey = "Nickname";
        private const string _selectedAvatarKey = "SelectedAvatar"; 

        private const string _coinsKey = "Coins";
        private const string _selectedBalloonKey = "SelectedBalloon";
        private const string _ownedBalloonsKey = "OwnedBalloons";

        private const string _levelUnlockedKeyPrefix = "Level_";

        public static float GetSoundVolume() => PlayerPrefs.GetFloat(_soundVolumeKey, 1f);
        public static void SetSoundVolume(float value) => PlayerPrefs.SetFloat(_soundVolumeKey, Mathf.Clamp01(value));

        public static float GetMusicVolume() => PlayerPrefs.GetFloat(_musicVolumeKey, 1f);
        public static void SetMusicVolume(float value) => PlayerPrefs.SetFloat(_musicVolumeKey, Mathf.Clamp01(value));

        public static bool GetNotificationEnabled() => PlayerPrefs.GetInt(_notificationKey, 1) == 1;
        public static void SetNotificationEnabled(bool enabled) => PlayerPrefs.SetInt(_notificationKey, enabled ? 1 : 0);

        public static string GetNickname() => PlayerPrefs.GetString(_nicknameKey, "Name Nickname");
        public static void SetNickname(string name) => PlayerPrefs.SetString(_nicknameKey, name);

        public static string GetAvatar() => PlayerPrefs.GetString(_selectedAvatarKey, "default_avatar");
        public static void SetAvatar(string avatarPath) => PlayerPrefs.SetString(_selectedAvatarKey, avatarPath);

        public static int GetCoins() => PlayerPrefs.GetInt(_coinsKey, 1000);
        public static void SetCoins(int amount) => PlayerPrefs.SetInt(_coinsKey, Mathf.Max(0, amount));

        public static int GetPlayerScore() => PlayerPrefs.GetInt("PlayerScore", 0);
        public static void SetPlayerScore(int score) => PlayerPrefs.SetInt("PlayerScore", score);

        public static string GetSelectedBalloon() => PlayerPrefs.GetString(_selectedBalloonKey, "default_balloon");
        public static void SetSelectedBalloon(string balloonId) => PlayerPrefs.SetString(_selectedBalloonKey, balloonId);
        public static void MarkBalloonOwned(string id) => PlayerPrefs.SetInt("Balloon_" + id, 1);

        public static void SetLevelStars(int levelNumber, int stars)
        {
            stars = Mathf.Clamp(stars, 0, 3);
            PlayerPrefs.SetInt($"LevelStars_{levelNumber}", stars);
        }

        public static int GetLevelStars(int levelNumber)
        {
            return PlayerPrefs.GetInt($"LevelStars_{levelNumber}", 0);
        }

        public static void AddOwnedBalloon(string balloonId)
        {
            var owned = GetOwnedBalloons();
            if (!owned.Contains(balloonId))
            {
                owned.Add(balloonId);
                SaveOwnedBalloons(owned);
            }
        }

        public static bool IsBalloonOwned(string balloonId)
        {
            var owned = GetOwnedBalloons();
            return owned.Contains(balloonId);
        }

        public static List<string> GetOwnedBalloons()
        {
            string saved = PlayerPrefs.GetString(_ownedBalloonsKey, "default_balloon");
            return new List<string>(saved.Split(','));
        }

        private static void SaveOwnedBalloons(List<string> owned)
        {
            string joined = string.Join(",", owned);
            PlayerPrefs.SetString(_ownedBalloonsKey, joined);
        }

        public static bool IsLevelUnlocked(int levelNumber)
        {
            return PlayerPrefs.GetInt(_levelUnlockedKeyPrefix + levelNumber, levelNumber == 1 ? 1 : 0) == 1;
        }

        public static void UnlockLevel(int levelNumber)
        {
            PlayerPrefs.SetInt(_levelUnlockedKeyPrefix + levelNumber, 1);
        }

        public static void SaveAll()
        {
            PlayerPrefs.Save();
        }

        public static void ResetAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}