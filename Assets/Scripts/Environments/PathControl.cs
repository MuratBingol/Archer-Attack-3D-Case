using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PathControl : MonoBehaviour
{
    public static event Action OnSetAttackPoint; 
    public static event Action<SplineComputer> OnSetPath; 
    void Start()
    {
        OnSetPath?.Invoke(GetComponent<SplineComputer>());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && transform.childCount>0)
        {
            transform.GetChild(0).SetParent(null);
        }
    }
    


    public void AttackPoint()
    {
        OnSetAttackPoint?.Invoke();
    }
}
