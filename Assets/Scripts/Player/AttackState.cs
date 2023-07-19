﻿using System;
using UnityEngine;

namespace Player
{
    public class AttackState: MonoBehaviour,IState
    {
        private PlayerControl _playerControl;
        public static Action OnAttackState;
        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
            if (_playerControl==null)
            {
                _playerControl=control as PlayerControl;;
            }
            enabled = true;
            OnAttackState?.Invoke();
            Invoke(nameof(SetIdle),0.8f);
        }

        private void SetIdle()
        {
            transform.eulerAngles=Vector3.up*transform.eulerAngles.y;
            _playerControl.UpdateState(_playerControl.idleState);
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}