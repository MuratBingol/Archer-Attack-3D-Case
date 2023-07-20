using System;
using Damagable;
using Dreamteck.Splines;
using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerControl:StateControl<PlayerControl>,IDamageable
    {
        [SerializeField] private PlayerData _playerData;
        public IState idleState,aimState,attackState,deadState,runState;
        public static  Action<Transform> OnPlayerInit; 
        public PlayerView playerView;
        private UnityEvent<float, float> OnTakeDamage;

        protected override void Awake()
        {
            base.Awake();
            PathControl.OnSetPath += SetPath;
            PathControl.OnSetAttackPoint += SetIdleState;
            EventManager.OnSetAction += ContinueRun;
            playerView.SetView(_playerData);
        }

        private void SetPath(SplineComputer path)
        {
            playerView.SetFollower(path);
        }

        private void Start()
        {
            OnPlayerInit?.Invoke(transform);
            UpdateState(idleState);
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
        
        private void ContinueRun(ActionType actionType)
        {
            if (actionType==ActionType.run)
            {
                UpdateState(runState);
            }
        }


        public void TakeDamage(float damage,Vector3 contactPoint)
        {
            playerView.health -= damage;
            OnTakeDamage?.Invoke(playerView.health,_playerData.health);
            if (playerView.health<=0 && _currentState!=deadState)
            {
                UpdateState(deadState);
                Destroy(this);
            }
        }

        public UnityEvent<float, float> GetDamageAction()
        {
            if (OnTakeDamage==null)
            {
                OnTakeDamage = new UnityEvent<float, float>();
            }

            return OnTakeDamage;
        }
    }
}