using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class DeadState : MonoBehaviour, IState
    {
        public static Action OnSetDead;
        private PlayerControl _playerControl;

        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
            if (_playerControl == null)
            {
                _playerControl = control as PlayerControl;
                
            }

            OnSetDead?.Invoke();
            EventManager.OnSetAction?.Invoke(ActionType.dead);
            enabled = true;
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}