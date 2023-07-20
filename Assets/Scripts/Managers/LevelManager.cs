using System;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.OnWin += Win;
            EventManager.OnFail += Fail;
        }

        private void DisableEvents()
        {
            EventManager.OnWin -= Win;
            EventManager.OnFail -= Fail;
        }

        private void Fail()
        {
            print("fail");
        }

        private void Win()
        {
           print("win");
        }
    }
}
