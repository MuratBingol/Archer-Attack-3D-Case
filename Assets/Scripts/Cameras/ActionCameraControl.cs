using Cinemachine;
using Managers;
using Player;
using UnityEngine;

namespace Cameras
{
    public class ActionCameraControl : MonoBehaviour
    {
        [SerializeField] private ActionType _type;
        private CinemachineVirtualCamera _camera;
        
        protected virtual void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            EventManager.OnSetAction += ChangeCameraState;
            PlayerControl.OnPlayerInit += SetCamera;
        }

        private void OnDisable()
        {
            EventManager.OnSetAction -= ChangeCameraState;
            PlayerControl.OnPlayerInit -= SetCamera;
        }

        protected void SetCamera(Transform obj)
        {
            _camera.m_Follow = obj;
            _camera.m_LookAt = obj;
        }

        private void ChangeCameraState(ActionType actionType)
        {
            if (actionType == _type)
            {
                _camera.m_Priority = 10;
                return;
            }

            _camera.m_Priority = 1;
        }
        
    }
}