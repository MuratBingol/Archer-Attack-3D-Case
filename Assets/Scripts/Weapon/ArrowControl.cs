using Cinemachine;
using UI;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    private Vector3 _target;

    private void Awake()
    {
        AimUIControl.OnSetTarget += GoTarget;
        enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * 4);

        transform.position = Vector3.Lerp(transform.position, _target, 0.01f);
    }

    private void GoTarget(Vector3 target)
    {
        transform.SetParent(null);
        _camera.m_Priority = 80;
        _target = target;
        transform.LookAt(_target);
        enabled = true;
    }
}