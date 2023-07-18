using System;
using System.Collections;
using System.Collections.Generic;
using Damagable;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IDamageable
{
    [SerializeField] private Color _aimColor;
    public static Action<Transform> OnDead;

    public abstract void TakeDamage(float damage);

    public Color GetAimColor()
    {
        return _aimColor;
    }

    protected virtual void Dead()
    {
        enabled = false;
    }
}
