using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAnimationControl : MonoBehaviour
{
    public static Action OnKeepWeapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAction()
    {
        OnKeepWeapon?.Invoke();
    }
}
