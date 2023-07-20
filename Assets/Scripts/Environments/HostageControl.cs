using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class HostageControl : EnvironmentBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _damageParticle;

    private void Awake()
    {
        EnemyArea.OnSafedArea += Save;
    }

    private void Save(Transform obj)
    {
        if (obj==transform.parent)
        {
            _animator.SetTrigger("walk");
        }
    }
    public override void TakeDamage(float damage, Vector3 contactPoint)
    {
        _damageParticle.Play();
        EventManager.OnSetAction?.Invoke(ActionType.dead);
        enabled = false;
        Destroy(this);
    }
    
}
