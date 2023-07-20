using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class KeepAnimationControl : MonoBehaviour
    {
        public static Action OnKeepWeapon;
  
        public void TriggerAction()
        {
            OnKeepWeapon?.Invoke();
        }
    }
}