using System;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static Action<ActionType> OnSetAction;
        public static Action OnStartGame,OnWin,OnFail;
     
    }
}
