using System;
using System.Collections;
using System.Collections.Generic;
using Damagable;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnvironmentBase : MonoBehaviour,IAttackable
{
    private UnityEvent<float, float> OnTakeDamage;
    [SerializeField] private Color _color;

    protected virtual void Start()
    {
       OnTakeDamage?.Invoke(0,0);
    }

    public abstract void TakeDamage(float damage, Vector3 contactPoint);

    public UnityEvent<float, float> GetDamageAction()
    {
        if (OnTakeDamage == null) OnTakeDamage = new UnityEvent<float, float>();
        return OnTakeDamage;
    }

    public Color GetAimColor()
    {
        return _color;
    }
}
