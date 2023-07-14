using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    [SerializeField] private bool _isDontDestroy;

    public T Instance { get; private set; }

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
            Instance = this as T;
        }

        if (_isDontDestroy) DontDestroyOnLoad(this);
    }
}