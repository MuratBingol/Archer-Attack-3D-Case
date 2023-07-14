using System;
using UnityEngine;

namespace Player
{
    public class DeadState: MonoBehaviour,IState
    {
        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
          
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}