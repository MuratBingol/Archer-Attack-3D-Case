using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    private void Awake()
    {
        EnemyBase.OnDead += DeadControl;
    }

    private void DeadControl(Transform enemy)
    {
        if (enemy.parent==transform)
        {
            enemy.SetParent(null);
            EnemyControl();
        }
    }

    private void EnemyControl()
    {
        if (transform.childCount>0)
        {
            EventManager.OnSetAction?.Invoke(ActionType.idle);
            return;
        }
        EnemyManager.Instance.RemoveArea();
       
    }

    private void Start()
    {
        InitialsEnemies();
    }

    private void InitialsEnemies()
    {
        if (EnemyManager.Instance == null)
        {
            GameObject manager = Instantiate(new GameObject());
            manager.AddComponent<EnemyManager>();
        }
        EnemyManager.Instance.areaCount++;
    }
    
}