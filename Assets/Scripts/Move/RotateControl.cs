using Player;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    [SerializeField] private float _treshdold;
    private Camera _camera;
    private Vector3 _firstPos, _lastPos;
    private Vector3 lastEuler;

    private void Awake()
    {
        _camera = Camera.main;
        AimState.OnSetAim += EnableControl;
        IdleState.OnSetIdle += () => enabled = false;
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
            var newEuler = (_lastPos - _firstPos) * _treshdold + lastEuler;
            ClampValue(ref newEuler.x);
            transform.eulerAngles = newEuler;
        }

        if (Input.GetMouseButtonUp(0)) enabled = false;
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
}