using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class AimState : MonoBehaviour, IState
    {
        public static Action OnSetAim;
        private PlayerControl _playerControl;

        private void Awake()
        {
            enabled = false;
            KeepAnimationControl.OnKeepWeapon += KeepWeapon;

        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _playerControl.UpdateState(_playerControl.attackState);
                enabled = false;
            }
        }

        private void OnDestroy()
        {
            KeepAnimationControl.OnKeepWeapon -= KeepWeapon;
        }

        public void EnterState<T>(T control)
        {
            if (_playerControl == null)
            {
                _playerControl = control as PlayerControl;
            }
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.aim);
            EventManager.OnSetAction?.Invoke(ActionType.aim);
        }

        public void ExitState()
        {
            _playerControl.playerView.GetRigidBody().isKinematic = false;
            enabled = false;
        }
        private void EnabledIdle()
        {
            enabled = true;
        }


        private void KeepWeapon()
        {
            OnSetAim?.Invoke();
            _playerControl.playerView.GetFollower().follow = false;
            var weapon = _playerControl.playerView.GetWeapon();
            _playerControl.playerView.SetToHand(weapon);
            weapon.localPosition = Vector3.zero;
            weapon.localEulerAngles = Vector3.zero;
            Invoke(nameof(EnabledIdle),0.5f);
        }
    }
}