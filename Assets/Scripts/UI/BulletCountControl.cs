using System;
using Managers;
using Player;
using TMPro;
using UnityEngine;

public class BulletCountControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private void Awake()
    {
        AttackState.OnAttackState += SetCount;
        EventManager.OnSetAction += CountControl;
    }

    private void Start()
    {
        SetCount();
    }

    private void CountControl(ActionType obj)
    {
        if (obj == ActionType.idle)
        {
            SetCount();
        }
    }


    private void SetCount()
    {
        _countText.text = "x" + LevelManager.Instance.bulletCount;
    }

    private void OnDisable()
    {
        AttackState.OnAttackState -= SetCount;
        EventManager.OnSetAction -= CountControl;
    }
}