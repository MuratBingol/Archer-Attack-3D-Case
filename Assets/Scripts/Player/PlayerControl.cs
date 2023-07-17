using System;
using Dreamteck.Splines;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class PlayerControl:StateControl<PlayerControl>
    {
        [SerializeField] private PlayerData _playerData;
        public IState idleState,aimState,attackState,deadState,runState;
        private IState _currentState;
        public static  Action<Transform> OnPlayerInit; 
        public PlayerView playerView;

        protected override void Awake()
        {
            base.Awake();
            PathControl.OnSetPath += SetPath;
            PathControl.OnSetAttackPoint += SetIdleState;
            playerView.SetView(_playerData);
        }

        private void SetPath(SplineComputer path)
        {
            playerView.SetFollower(path);
        }

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
            UpdateState(runState);
        }

        protected override void InitializeStates()
        {
            idleState = gameObject.AddComponent<IdleState>();
            aimState = gameObject.AddComponent<AimState>();
            attackState = gameObject.AddComponent<AttackState>();
            deadState = gameObject.AddComponent<DeadState>();
            runState = gameObject.AddComponent<RunState>();
        }
        
        private void SetIdleState()
        {
            UpdateState(idleState);
        }

        
    }
}