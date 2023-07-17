using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class AimUIControl : MonoBehaviour
    {
        [SerializeField] private Image _aimImage;
        public static Action<Vector3> OnSetTarget;
        private Camera _camera;
        private Vector3 _targetPos;
        private void Awake()
        {
            Player.AimState.OnSetAim += SetAimUI;
            Player.AttackState.OnAttackState += Attack;
            _camera=Camera.main;;
        }

        private void Attack()
        {
            _aimImage.enabled = false;
            OnSetTarget?.Invoke(_targetPos);
        }

        private void SetAimUI()
        {
            _aimImage.enabled = true;
            StartCoroutine(AimControl());
        }

        IEnumerator AimControl()
        {
            while (true)
            {
                Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
                print("sd");
                if (Physics.Raycast(ray,out RaycastHit hit))
                {
                    _targetPos = hit.point;
                    print(_targetPos);
                }
                yield return null;
            }
        }
    }
}