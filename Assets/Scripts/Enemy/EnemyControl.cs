using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class EnemyControl : EnemyBase
{
    private SplineFollower _splineFollower;
    void Start()
    {
        _splineFollower = GetComponent<SplineFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        OnDead?.Invoke(transform);
       _animator.enabled = false;
       print("take");
       FindRigidbodies(transform);
       Destroy(this);
    }
    
    

    public void Stop()
    {
        _splineFollower.follow = false;
        Invoke(nameof(Continue),5);
    }

    private void Continue()
    {
        _splineFollower.follow = true;
    }
    
}
