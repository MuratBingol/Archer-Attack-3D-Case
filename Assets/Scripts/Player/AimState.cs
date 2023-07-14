using System;
using UnityEngine;

namespace Player
{
    public class AimState: MonoBehaviour,IState
    {
        private PlayerControl _playerControl;
        public static Action OnSetAim;
        private void Awake()
        {
            enabled = false;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerControl.playerView.ChangeAnimation(PlayerAnimType.shoot);
                _playerControl.UpdateState(_playerControl.idleState);
            }
        }


        public void EnterState<T>(T control)
        {
            OnSetAim?.Invoke();
            enabled = true;
            if (_playerControl==null)
            {
                _playerControl= control as PlayerControl;;
            }
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.aim);
            Invoke(nameof(KeepWeapon),0.9f);
        }

        public void ExitState()
        {
            enabled = false;
        }

        private void KeepWeapon()
        {
            EventManager.OnSetAction?.Invoke(ActionType.aim);
            Transform weapon = _playerControl.playerView.GetWeapon();
            _playerControl.playerView.SetToHand(weapon);
            weapon.localPosition=Vector3.zero;
            weapon.localEulerAngles = Vector3.zero;
        }
    }
}