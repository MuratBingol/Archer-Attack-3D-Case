using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Datas/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public int defaultLevel;
        [SerializeField] private List<Level> _levels;
        public int LastLevel
        {
            get => PlayerPrefs.GetInt("Level", defaultLevel);
            private set => PlayerPrefs.SetInt("Level", value);
        }
        public int PlayedLevelCount
        {
            get => PlayerPrefs.GetInt("PlayedLevel", defaultLevel);
            private set => PlayerPrefs.SetInt("PlayedLevel", value);
        }

        public Level CurrentLevel
        {
            get => _levels[LastLevel-defaultLevel];
        }

        public void SetNextLevel()
        {
            LastLevel++;
            PlayedLevelCount++;
            if (LastLevel>_levels.Count)
            {
                LastLevel = defaultLevel;
            }
        }
    }


    [Serializable]
    public class Level
    {
        public int bulletCount;
        public int levelAward;
    }
}