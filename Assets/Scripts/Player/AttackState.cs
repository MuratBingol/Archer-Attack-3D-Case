using System;
using UnityEngine;

namespace Player
{
    public class AttackState: MonoBehaviour,IState
    {
        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
            enabled = true;
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}