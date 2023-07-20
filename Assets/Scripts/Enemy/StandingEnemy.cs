using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class StandingEnemy : EnemyBase
{

    protected override void InitializeStates()
    {
        fallState = gameObject.AddComponent<FallState>();
        fireState = gameObject.AddComponent<FireState>();
    }
}
