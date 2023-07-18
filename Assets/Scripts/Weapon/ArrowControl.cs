using Cinemachine;
using UI;
using UnityEngine;

namespace Weapon
{
    public class ArrowControl : BulletBase
    {
        [SerializeField] private TrailRenderer _trail;
        
        protected override void Awake()
        {
            base.Awake();
            _trail.enabled = false;
        }
        
        private void Update()
        { 
            transform.Rotate(Vector3.forward * 2);
        }


        protected override void Go()
        {
            _camera.m_Priority = 80;
            _trail.enabled = true;
        }

        protected override void DisableBullet(Transform target)
        {
            base.DisableBullet(target);
            _trail.enabled = false;
        }
    }
}