using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class RunState : MonoBehaviour, IState
    {
        public static Action OnSetRun;
        private PlayerControl _playerControl;
        private void Awake()
        {
            enabled = false;

        }
        
        public void EnterState<T>(T control)
        {
            enabled = true;
            OnSetRun?.Invoke();
            if (_playerControl == null) _playerControl = control as PlayerControl;
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.walk);
            _playerControl.playerView.SetSpeed(2);
            _playerControl.playerView.GetFollower().follow = enabled;
        }


        public void ExitState()
        {
            enabled = false;
            _playerControl.playerView.SetSpeed(0);
        }
    }
}