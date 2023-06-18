using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private GameObject stunVFXPrefab;
    // [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private bool isStunned = false;

    private Animator animator;

    readonly int STUN_HASH = Animator.StringToHash("Stunned");

    private int currentHealth;
    // private Knockback knockback;
    // private Flash flash;

    // private void Awake()
    // {
    //     flash = GetComponent<Flash>();
    //     knockback = GetComponent<Knockback>();
    // }


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        // StartCoroutine(flash.FlashRoutine());
        // StartCoroutine(CheckDetectDeathRoutine());
        DetectDeath();
    }

    public void Stun()
    {
        Instantiate(stunVFXPrefab, transform.position, Quaternion.identity);
        if (isStunned)
        {
            animator.SetTrigger(STUN_HASH);
        }
    }

    // private IEnumerator CheckDetectDeathRoutine()
    // {
    //     yield return new WaitForSeconds(flash.GetRestoreMatTime());
    //     DetectDeath();
    // }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}