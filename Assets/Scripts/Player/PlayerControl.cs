using System;
using UnityEngine;

namespace Player
{
    public class PlayerControl:StateControl<PlayerControl>
    {
        public IState idleState,aimState,attackState,deadState;
        private IState _currentState;

        public PlayerView playerView;
        
        protected override void InitializeStates()
        {
            idleState = gameObject.AddComponent<IdleState>();
            aimState = gameObject.AddComponent<AimState>();
            attackState = gameObject.AddComponent<AttackState>();
            deadState = gameObject.AddComponent<DeadState>();
            UpdateState(idleState);
        }
    }
}