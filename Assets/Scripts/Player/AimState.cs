using System;
using Managers;
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
            KeepAnimationControl.OnKeepWeapon += KeepWeapon;
        }
        public void EnterState<T>(T control)
        {
            if (_playerControl==null)
            {
                _playerControl= control as PlayerControl;;
            }
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.aim);
            EventManager.OnSetAction?.Invoke(ActionType.aim);

        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            { 
                _playerControl.UpdateState(_playerControl.attackState);
            }
        }

        public void ExitState()
        {
            _playerControl.playerView.GetRigidBody().isKinematic = false;
            enabled = false;
        }

        private void KeepWeapon()
        {
            OnSetAim?.Invoke();
            _playerControl.playerView.GetFollower().follow = false;
            Transform weapon = _playerControl.playerView.GetWeapon();
            _playerControl.playerView.SetToHand(weapon);
            weapon.localPosition=Vector3.zero;
            weapon.localEulerAngles = Vector3.zero;
            enabled = true;
        }
    }
}