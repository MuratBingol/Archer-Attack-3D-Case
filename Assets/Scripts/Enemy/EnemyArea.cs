using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Weapon;

public class EnemyArea : MonoBehaviour
{
    private int _enemyCount;
    public static Action<Transform> OnStartFire;
    public static Action<Transform> OnSafedArea;
    private void Awake()
    {
        EnemyBase.OnDead += DeadControl;
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletBase _bullet = other.GetComponent<BulletBase>();
        if (_bullet!=null)
        {
            OnStartFire?.Invoke(transform);
            GetComponent<Collider>().enabled = false;
        }
    }

    private void DeadControl(Transform enemy)
    {
        if (enemy.parent==transform)
        {
            enemy.SetParent(null);
            _enemyCount--;
            EnemyControl();
        }
    }
    private void EnemyControl()
    {
        if (_enemyCount>0)
        {
            EventManager.OnSetAction?.Invoke(ActionType.idle);
            return;
        }
        OnSafedArea?.Invoke(transform);
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

        foreach (Transform child in transform)
        {
            if (child.GetComponent<EnemyBase>()!=null)
            {
                _enemyCount++;
            }
        }
    }
    
}