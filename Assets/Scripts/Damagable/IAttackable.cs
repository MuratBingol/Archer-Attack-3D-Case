using UnityEngine;
using UnityEngine.Events;

namespace Damagable
{
    public interface IAttackable: IDamageable
    {
        Color GetAimColor();
        
    }
}