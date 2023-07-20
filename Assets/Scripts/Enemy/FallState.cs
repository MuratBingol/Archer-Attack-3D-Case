using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class FallState : MonoBehaviour, IState
    {
        private Coroutine _coroutine;
        private EnemyBase _enemyBase;

        private void Awake()
        {
            enabled = false;
        }

        public void EnterState<T>(T control)
        {
            if (_enemyBase == null) _enemyBase = control as EnemyBase;
            _enemyBase.animator.SetTrigger("Fall");
            enabled = true;
            if (_coroutine == null) _coroutine = StartCoroutine(ControlStand());
        }

        public void ExitState()
        {
            enabled = false;
            if (_coroutine!=null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator ControlStand()
        {
            yield return new WaitForSeconds(0.5f);
            while (true)
            {
                if (_enemyBase.animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
                {
                    _enemyBase.UpdateState(_enemyBase.fireState);
                    yield break;
                }
                yield return null;
            }
        }
    }
}