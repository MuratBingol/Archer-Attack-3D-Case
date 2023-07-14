using System;
using UnityEngine;

namespace Player
{
    public class IdleState : MonoBehaviour, IState
    {
        private PlayerControl _playerControl;
        public static event Action<Transform> OnPlayerInit; 

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
                _playerControl.UpdateState(_playerControl.aimState);
            }
        }

        public void EnterState<T>(T control)
        {
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