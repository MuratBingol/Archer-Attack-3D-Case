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

    public void Stop()
    {
        _splineFollower.follow = false;
        Invoke(nameof(Continue),5);
    }

    private void Continue()
    {
        _splineFollower.follow = true;
    }

    protected override void InitializeStates()
    {
        
    }
}
