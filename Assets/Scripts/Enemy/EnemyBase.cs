using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";

    public HealthBase healthBase;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    public void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
