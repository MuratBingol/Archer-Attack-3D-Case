using System;
using Player;
using ScriptableObjects.Level;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private LevelData _levelData;
        public static UnityEvent<AsyncOperation> OnLoadScene;
        public int bulletCount;
        public int playedLevel;
        public Level currentLevel;

        protected override void Awake()
        {
            base.Awake();
            currentLevel = _levelData.CurrentLevel;
            EventManager.OnWin += Win;
            EventManager.OnFail += Fail;
            AttackState.OnAttackState += BulletControl;
            OnLoadScene = new UnityEvent<AsyncOperation>();
            bulletCount = currentLevel.bulletCount;
        }

        private void BulletControl()
        {
            bulletCount--;
        }

        private void DisableEvents()
        {
            EventManager.OnWin -= Win;
            EventManager.OnFail -= Fail;
            AttackState.OnAttackState -= BulletControl;
        }

        private void Fail()
        {
            DisableEvents();
        }

        private void Win()
        {
            _levelData.SetNextLevel();
            DisableEvents();
        }

        public void OpenLastLevel()
        {
            AsyncOperation loadProgress =  SceneManager.LoadSceneAsync(_levelData.LastLevel);
            OnLoadScene?.Invoke(loadProgress);
        }
    }
}
