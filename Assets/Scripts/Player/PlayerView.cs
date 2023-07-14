using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _keepPoint;
        [SerializeField] private WeaponManager _weaponBucket;

        
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
        
        
    }
}