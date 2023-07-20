using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingControl : MonoBehaviour
{
    [SerializeField] private Image _loadingImage;
    [SerializeField] private GameObject _panel;

    private AsyncOperation loading;

    private void Awake()
    {
        LevelManager.OnLoadScene?.AddListener(LoadUI);
    }
    
    private void Update()
    {
        if (loading == null) return;

        if (!loading.isDone)
        {
            _loadingImage.fillAmount = loading.progress / 0.9f;
            return;
        }
        
        enabled = false;
    }


    private void LoadUI(AsyncOperation loadingProgress)
    {
        print(1);
        _panel.SetActive(true);
        loading = loadingProgress;
    }

    private void OnDisable()
    {
        LevelManager.OnLoadScene?.RemoveListener(LoadUI);
    }
}