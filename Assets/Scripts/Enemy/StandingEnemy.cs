using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : EnemyBase
{
    

    public override void TakeDamage(float damage)
    {
        OnDead?.Invoke(transform);
        _animator.enabled = false;
        Destroy(this);
    }
}
