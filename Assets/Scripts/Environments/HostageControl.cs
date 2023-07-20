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
    
    protected void FindRigidbodies(Transform parentTransform)
    {
        var rigidbodies = parentTransform.GetComponentsInChildren<Rigidbody>();

        foreach (var rb in rigidbodies) rb.isKinematic = false;

        foreach (Transform child in parentTransform) FindRigidbodies(child);
    }
    public override void TakeDamage(float damage, Vector3 contactPoint)
    {
        _animator.enabled = false;
        FindRigidbodies(transform);
        _damageParticle.transform.position = contactPoint;
        _damageParticle.Play();
        EventManager.OnSetAction?.Invoke(ActionType.dead);
        EventManager.OnFail?.Invoke();
        enabled = false;
        Destroy(this);
    }
    
}
