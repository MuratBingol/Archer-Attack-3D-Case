using System;
using UnityEngine;
using UnityEngine.Events;

namespace Damagable
{
    public interface IDamageable
    {
        void TakeDamage(float damage,Vector3 contactPoint);
        UnityEvent<float,float> GetDamageAction();
    }
}