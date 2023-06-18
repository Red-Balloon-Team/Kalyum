using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private GameObject stunVFXPrefab;
    // [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] public bool isStunned = false;

    private Animator animator;
    private EnemyHuman enemyHuman;
    private ItemText itemText;
    private float timer = 0f;
    private float stunDuration = 3f;

    readonly int STUN_HASH = Animator.StringToHash("Stunned");
    readonly int IDLE_HASH = Animator.StringToHash("Idle");

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
        enemyHuman = GetComponent<EnemyHuman>();
        itemText = GetComponentInChildren<ItemText>();
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

        if (isStunned)
        {
            Instantiate(stunVFXPrefab, transform.position, Quaternion.identity);
            animator.SetTrigger(STUN_HASH);
            animator.ResetTrigger(IDLE_HASH);
            enemyHuman.isStunned = true;
            itemText.EnemyHumanPrompt();

            StopAllCoroutines();
            StartCoroutine(EndStunDelayed());
        }
    }

    private IEnumerator EndStunDelayed()
    {
        yield return new WaitForSeconds(stunDuration);

        enemyHuman.isStunned = false;
        itemText.HidePrompt();
        animator.SetTrigger(IDLE_HASH);
        animator.ResetTrigger(STUN_HASH);
        
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