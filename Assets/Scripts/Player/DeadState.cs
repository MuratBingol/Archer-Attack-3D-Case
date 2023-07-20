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
            Destroy(_playerControl);
            OnSetDead?.Invoke();
            EventManager.OnFail?.Invoke();
            EventManager.OnSetAction?.Invoke(ActionType.dead);
            _playerControl.playerView.GetFollower().enabled = false;
            
            enabled = true;
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.dead);
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}