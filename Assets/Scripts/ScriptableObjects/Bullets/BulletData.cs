using System;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/Datas/BulletData", order = 0)]
    public class BulletData : ScriptableObject
    {
        public float speed;
        public int damage;
        public float maxDistance;
    }
}