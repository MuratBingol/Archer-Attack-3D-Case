using System;
using System.Collections;
using Damagable;
using UnityEngine;

namespace Enemy
{
    public class FireState : MonoBehaviour, IState
    {
        private Coroutine _attackCoroutine;
        private EnemyBase _enemyBase;
        private IDamageable _damageable;

        private void Awake()
        {
            enabled = false;
        }
        

        public void EnterState<T>(T control)
        {
            if (_enemyBase == null) _enemyBase = control as EnemyBase;
            enabled = true;
            _damageable = _enemyBase.player.GetComponent<IDamageable>();
            _enemyBase.animator.SetTrigger("fire");
            transform.LookAt(_enemyBase.player);
            if (_attackCoroutine == null) _attackCoroutine = StartCoroutine(Damage());
        }

        public void ExitState()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
            enabled = false;
        }

        private IEnumerator Damage()
        {
            var delay = new WaitForSeconds(1);
            while (true)
            {
                _enemyBase.hitParticle.Play();
                _damageable.TakeDamage(_enemyBase.damage,Vector3.zero);
                yield return delay;
              
            }
        }
    }
}