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
            if (Input.GetMouseButtonDown(0))
            {
               _playerControl.UpdateState(_playerControl.aimState);
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