using System;
using UnityEngine;

namespace Player
{
    public class IdleState : MonoBehaviour, IState
    {
        private PlayerControl _playerControl;
        public static  Action<Transform> OnPlayerInit;
        public static  Action OnSetIdle;

        private void Awake()
        {
            enabled = false;
        }

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerControl.UpdateState(_playerControl.runState);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _playerControl.UpdateState(_playerControl.deadState);
            }
        }

        public void EnterState<T>(T control)
        {
            OnSetIdle?.Invoke();
            EventManager.OnSetAction?.Invoke(ActionType.idle);
            enabled = true;
            _playerControl = control as PlayerControl;
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.idle);
        }

        public void ExitState()
        {
            enabled = false;
        }
    }
}