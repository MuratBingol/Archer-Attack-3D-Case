using UnityEngine;

namespace Managers
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private bool _isDontDestroy;

        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            if (_isDontDestroy) DontDestroyOnLoad(this);
        }
    }
}