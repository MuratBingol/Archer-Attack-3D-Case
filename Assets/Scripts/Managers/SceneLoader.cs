using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        LevelManager.Instance.OpenLastLevel();
    }

}
