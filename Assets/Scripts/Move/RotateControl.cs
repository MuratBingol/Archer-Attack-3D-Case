using System;
using Managers;
using Player;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    [SerializeField] private float _treshdold;
    private Camera _camera;
    private Vector3 _firstPos, _lastPos;
    private Vector3 lastEuler;
    private Vector3 newEuler;

    private void Awake()
    {
        _camera = Camera.main;
        AimState.OnSetAim += EnableControl;
        DeadState.OnSetDead += Disable;
        AttackState.OnAttackState += Disable;
        EventManager.OnFail += Disable;
        EventManager.OnWin += Disable;
    }

    private void Disable()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        newEuler = transform.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = GetPosition();
            lastEuler = transform.eulerAngles;
        }

        if (Input.GetMouseButton(0))
        {
            _lastPos = GetPosition();
            newEuler = (_lastPos - _firstPos) * _treshdold + lastEuler;
            ClampValue(ref newEuler.x);
        }
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = newEuler;
    }

    private void EnableControl()
    {
        enabled = true;
        _firstPos = GetPosition();
        lastEuler = transform.eulerAngles;
    }

    private void ClampValue(ref float value)
    {
        if (value < 0 || value > 270)
            value = Mathf.Max(value, -60f);
        else
            value = Mathf.Min(value, +60f);
    }

    private Vector3 GetPosition()
    {
        return new Vector3(-_camera.ScreenToViewportPoint(Input.mousePosition).y,
            _camera.ScreenToViewportPoint(Input.mousePosition).x, 0);
    }

    private void OnDestroy()
    {
        AimState.OnSetAim -= EnableControl;
        DeadState.OnSetDead -= Disable;
        AttackState.OnAttackState -= Disable;
        EventManager.OnFail -= Disable;
        EventManager.OnWin -= Disable;
    }
}