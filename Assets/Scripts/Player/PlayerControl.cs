using System;
using UnityEngine;

namespace Player
{
    public class PlayerControl:StateControl<PlayerControl>
    {
        public IState idleState,aimState,attackState,deadState,runState;
        private IState _currentState;
        public static  Action<Transform> OnPlayerInit; 
        public PlayerView playerView;

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
        }

        protected override void InitializeStates()
        {
            idleState = gameObject.AddComponent<IdleState>();
            aimState = gameObject.AddComponent<AimState>();
            attackState = gameObject.AddComponent<AttackState>();
            deadState = gameObject.AddComponent<DeadState>();
            runState = gameObject.AddComponent<RunState>();
            UpdateState(idleState);
        }
    }
}