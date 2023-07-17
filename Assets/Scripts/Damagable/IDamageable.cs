using UnityEngine;

namespace Damagable
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        Color GetAimColor();
    }
}