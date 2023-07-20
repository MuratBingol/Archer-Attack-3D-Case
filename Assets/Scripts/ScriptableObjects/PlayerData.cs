using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Datas/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public float health;
    }
}