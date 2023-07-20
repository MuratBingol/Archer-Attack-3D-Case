using System;
using System.Collections;
using Damagable;
using Managers;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AimUIControl : MonoBehaviour
    {
        public static Action<Vector3> OnSetTarget;
        [SerializeField] private Image _aimImage;
        [SerializeField] private Color _defaultColor;
        private Camera _camera;
        private Collider _lastTargetCollider;
        private Vector3 _targetPos;

        private void Awake()
        {
            AimState.OnSetAim += SetAimUI;
            AttackState.OnAttackState += Attack;
            EventManager.OnSetAction += ((type => _aimImage.enabled = false));
            _camera = Camera.main;
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

        private IEnumerator AimControl()
        {
            while (true)
            {
                var ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out var hit))
                {
                    _targetPos = hit.point;
                    TargetControl(hit.collider);
                    yield return null;
                    continue;
                }
                ResetRaycast();
                yield return null;
            }
        }


        private void ResetRaycast()
        {
            
            _targetPos = Vector3.zero;
            _aimImage.color = _defaultColor;
            _lastTargetCollider = null;
        }
        private void TargetControl(Collider targetCollider)
        {
            _lastTargetCollider = targetCollider;
            var attackable = _lastTargetCollider.GetComponentInParent<IAttackable>();
            if (attackable != null)
            {
                _aimImage.color = attackable.GetAimColor();
                return;
            }
            _aimImage.color = _defaultColor;
        }
    }
}