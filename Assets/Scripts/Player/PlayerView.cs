using System;
using Dreamteck.Splines;
using Managers;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _keepPoint;
        [SerializeField] private WeaponManager _weaponBucket;
        [SerializeField] private SplineFollower _splineFollower;
        [SerializeField] private Rigidbody _rigidbody;



        public void SetView(PlayerData playerData)
        {
          //  _splineFollower.followSpeed = playerData.speed;
        }
        public void ChangeAnimation(PlayerAnimType animType)
        {
            _animator.SetInteger("state",(int)animType);
        }

        public void SetToHand(Transform obj)
        {
            obj.SetParent(_keepPoint);
        }

        public Transform GetWeapon()
        {
            return _weaponBucket.GetWeapon();
        }

        public void SetFollower(SplineComputer splineComputer)
        {
            _splineFollower.spline=splineComputer;
        }

        public SplineFollower GetFollower()
        {
            return _splineFollower;
        }

        public void SetSpeed(float speed)
        {
            _splineFollower.followSpeed = speed;
        }

        public Animator GetAnimator()
        {
            return _animator;
        }
        
        public Rigidbody GetRigidBody()
        {
            return _rigidbody;
        }


    }
}