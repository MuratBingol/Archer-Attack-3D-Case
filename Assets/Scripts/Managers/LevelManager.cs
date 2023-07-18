using System;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.OnWin += Win;
        }

        private void Win()
        {
           print("win");
        }
    }
}
