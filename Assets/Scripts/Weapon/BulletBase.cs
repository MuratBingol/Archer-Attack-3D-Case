using System;
using Cinemachine;
using Damagable;
using UI;
using UnityEngine;

namespace Weapon
{
    public abstract class BulletBase : MonoBehaviour
    {
        public static Action OnHit;
        [SerializeField] protected BulletData _bulletData;
        [SerializeField] protected CinemachineVirtualCamera _camera;
        private float _distance;
        private Vector3 _firstPos;
        protected Rigidbody _rigidbody;

        protected virtual void Awake()
        {
            AimUIControl.OnSetTarget += SetTarget;
            _rigidbody = GetComponent<Rigidbody>();
            enabled = false;
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(transform.position + transform.forward * _bulletData.speed);
            if (DistanceControl()) DestroyBullet();
        }

        private void OnCollisionEnter(Collision collision)
        {

            _camera.enabled = false;
            DisableBullet(collision.transform);
            IDamageable _damageable = collision.gameObject.GetComponent<IDamageable>();
            if (_damageable == null) _damageable =collision.gameObject.GetComponentInParent<IDamageable>();
            if (_damageable!=null)Hit(_damageable);
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRigidbody != null)
            {
                otherRigidbody.isKinematic = false;
                Vector3 pushDirection = collision.contacts[0].normal;
                otherRigidbody.AddForce(pushDirection * 20, ForceMode.Impulse); 
            }


        }

        protected abstract void Go();

        private void SetTarget(Vector3 target)
        {
            enabled = true;
            AimUIControl.OnSetTarget -= SetTarget;
            transform.SetParent(null);
            if (target == Vector3.zero)
            {
                target = transform.position + transform.forward;
                Invoke(nameof(DestroyBullet), 1f);
            }

            transform.LookAt(target);
            _distance = Vector3.Distance(transform.position, target);
            _firstPos = transform.position;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            Go();
        }

        private void DestroyBullet()
        {
            _camera.enabled = false;
            Destroy(gameObject, 3);
            OnHit?.Invoke();
        }

        private bool DistanceControl()
        {
            if (Vector3.Distance(transform.position, _firstPos) - _distance > 3) return true;
            return false;
        }

        protected virtual void DisableBullet(Transform target)
        {
            if (!enabled) return;
            _camera.m_LookAt = null;
            _camera.enabled = false;
            enabled = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.isKinematic = true;
            var neww = Instantiate(new GameObject());
            neww.transform.SetParent(target);
            transform.GetChild(0).SetParent(neww.transform, true);
        }
        private void Hit(IDamageable damageable)
        {
            damageable.TakeDamage(_bulletData.damage);
            OnHit?.Invoke();
        }
    }
}