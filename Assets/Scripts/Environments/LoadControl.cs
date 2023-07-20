using System;
using System.Collections;
using System.Collections.Generic;
using Damagable;
using UnityEngine;

public class LoadControl : EnvironmentBase
{
    [SerializeField] private Rigidbody _rigidbody;
  
    public override void TakeDamage(float damage, Vector3 contactPoint)
    {
        _rigidbody.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable _damageable = collision.gameObject.GetComponent<IDamageable>();
        if (_damageable == null) _damageable =collision.gameObject.GetComponentInParent<IDamageable>();
        if (_damageable!=null)
        {
            _rigidbody.drag = 3f;
            _damageable.TakeDamage(5000,collision.GetContact(0).point);
            Destroy(this);
        }
    }
}
