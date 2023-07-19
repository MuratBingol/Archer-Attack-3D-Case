using System;
using Damagable;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    public static Action<Transform> OnDead;
    [SerializeField] private Color _aimColor;
    [SerializeField] protected Animator _animator;

 
    public abstract void TakeDamage(float damage);

    public Color GetAimColor()
    {
        return _aimColor;
    }

    protected void FindRigidbodies(Transform parentTransform)
    {
        Rigidbody[] rigidbodies = parentTransform.GetComponentsInChildren<Rigidbody>();

        // Parent ve child'ların Rigidbody bileşenine erişebilirsiniz
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }

        // Parent'in tüm child'ları için tekrarlayın (rekürsif olarak)
        foreach (Transform child in parentTransform)
        {
            FindRigidbodies(child);
        }
    }

    protected virtual void Dead()
    {
        enabled = false;
    }
}