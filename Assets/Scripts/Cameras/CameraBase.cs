using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Player;
using UnityEngine;

public abstract class CameraBase : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    
    protected virtual void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        IdleState.OnPlayerInit += SetCamera;
    }
    
    protected void SetCamera(Transform obj)
    {
        _camera.m_Follow = obj;
        _camera.m_LookAt = obj;
    }

    private void EnableCamera()
    {
        _camera.enabled = true;
    }

    private void DisableCamera()
    {
        _camera.enabled = false;
    }

}
