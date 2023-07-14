using System;
using UnityEngine;

namespace Player
{
    public class AimState: MonoBehaviour,IState
    {
        private PlayerControl _playerControl;
        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
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
            Transform weapon = _playerControl.playerView.GetWeapon();
            _playerControl.playerView.SetToHand(weapon);
            weapon.localPosition=Vector3.zero;
            weapon.localEulerAngles = Vector3.zero;
        }
    }
}