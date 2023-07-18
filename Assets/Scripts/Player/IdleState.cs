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
        private PlayerControl _playerControl;
        private PointerEventData _eventData;
        private List<RaycastResult> _result;

        private void Awake()
        {
            enabled = false;
            _eventData = new PointerEventData(EventSystem.current);
            _result = new List<RaycastResult>();
            EventManager.OnSetAction += ContinueRun;
        }

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                if (ControlUITouch())
                    _playerControl.UpdateState(_playerControl.aimState);
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

        private void ContinueRun(ActionType actionType)
        {
            if (actionType==ActionType.run)
            {
                _playerControl.UpdateState(_playerControl.runState);
            }
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