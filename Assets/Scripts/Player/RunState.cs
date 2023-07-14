using System;
using UnityEngine;

namespace Player
{
    public class RunState : MonoBehaviour, IState
    {
        private PlayerControl _playerControl;
        public static  Action OnSetRun;

        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
            enabled = true;
            OnSetRun?.Invoke();
            EventManager.OnSetAction?.Invoke(ActionType.run);
            if (_playerControl == null) _playerControl = control as PlayerControl;
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.walk);
        }
        
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerControl.UpdateState(_playerControl.aimState);
            }
        }


        public void ExitState()
        {
            enabled = false;
        }
    }
}