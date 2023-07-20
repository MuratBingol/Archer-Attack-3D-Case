using System;
using Damagable;
using Player;
using UnityEngine;
using UnityEngine.Events;
using Weapon;

public abstract class EnemyBase : StateControl<EnemyBase>, IAttackable
{
    public static Action<Transform> OnDead;
    public ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem _damageParticle;
    [SerializeField] private Color _aimColor;
    public Animator animator;
    public Transform player;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    public int damage;
    public IState fireState, fallState;
    protected UnityEvent<float, float> OnTakeDamage;


    protected override void Awake()
    {
        base.Awake();
        PlayerControl.OnPlayerInit += SetPlayer;
        BulletBase.OnHit += StartFire;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnTakeDamage?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage, Vector3 contactPoint)
    {
        _currentHealth -= damage;
        OnTakeDamage?.Invoke(_currentHealth, _maxHealth);
        _damageParticle.transform.position = contactPoint;
        _damageParticle.Play();
        if (_currentHealth > 0)
        {
            UpdateState(fallState);
            return;
        }

        Dead();
        OnDead?.Invoke(transform);
        animator.enabled = false;
        FindRigidbodies(transform);
        Destroy(this);
    }

    public Color GetAimColor()
    {
        return _aimColor;
    }

    public UnityEvent<float, float> GetDamageAction()
    {
        if (OnTakeDamage == null) OnTakeDamage = new UnityEvent<float, float>();

        return OnTakeDamage;
    }

    private void StartFire(Vector3 hitPos)
    {
        if (_currentState == fireState) return;
        if (Vector3.Distance(transform.position, hitPos) > 15) return;
        if (_currentState == fallState) return;
        UpdateState(fireState);
    }

    private void SetPlayer(Transform obj)
    {
        player = obj;
    }

    protected void FindRigidbodies(Transform parentTransform)
    {
        var rigidbodies = parentTransform.GetComponentsInChildren<Rigidbody>();

        foreach (var rb in rigidbodies) rb.isKinematic = false;

        foreach (Transform child in parentTransform) FindRigidbodies(child);
    }

    protected void Dead()
    {
        fireState.ExitState();
        enabled = false;
    }

    private void OnDisable()
    {
        PlayerControl.OnPlayerInit -= SetPlayer;
        BulletBase.OnHit -= StartFire;
    }
}