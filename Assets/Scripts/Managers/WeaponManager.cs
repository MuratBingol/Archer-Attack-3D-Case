using UnityEngine;

namespace Managers
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;
        public Transform GetWeapon()
        {
            GameObject weapon = Instantiate(_weaponPrefab);
            return weapon.transform;
        }
    }
}
