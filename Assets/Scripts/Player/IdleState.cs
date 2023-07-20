using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class IdleState : MonoBehaviour, IState
    {
        public static Action<Transform> OnPlayerInit;
        public static Action OnSetIdle;
        private PointerEventData _eventData;
        private PlayerControl _playerControl;
        private List<RaycastResult> _result;

        private void Awake()
        {
            enabled = false;
            _eventData = new PointerEventData(EventSystem.current);
            _result = new List<RaycastResult>();
        }

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
        }

        private void Update()
        {
            if (LevelManager.Instance.bulletCount <= 0) return;
            if (Input.GetMouseButtonDown(0))
                if (ControlUITouch())
                {
                    _playerControl.UpdateState(_playerControl.aimState);
                    enabled = false;
                }
                   
        }

        public void EnterState<T>(T control)
        {
            OnSetIdle?.Invoke();
            EventManager.OnSetAction?.Invoke(ActionType.idle);
            _playerControl = control as PlayerControl;
            _playerControl.playerView.ChangeAnimation(PlayerAnimType.idle);
            Invoke(nameof(EnabledIdle),0.5f);
        }

        private void EnabledIdle()
        {
            enabled = true;
        }

        public void ExitState()
        {
            enabled = false;
        }

        private bool ControlUITouch()
        {
            _result.Clear();
            _eventData.position = Input.mousePosition;
            EventSystem.current.RaycastAll(_eventData, _result);

            if (_result.Count > 0) return false;

            return true;
        }
    }
}