using System;
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
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.idle);
            _playerControl.playerView.GetFollower().follow = enabled;
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}