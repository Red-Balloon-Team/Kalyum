using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private GameObject stunVFXPrefab;
    // [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] public bool isStunned = false;

    private Animator animator;
    private UnlockDoor unlockDoor;
    private NameBoxManager nameBoxManager;
    private TextBoxManager textBoxManager;
    private EnemyHuman enemyHuman;
    private AltavozBoxManager imageBoxManager;
    private ItemText itemText;
    private float stunDuration = 3f;

    readonly int STUN_HASH = Animator.StringToHash("Stunned");
    readonly int IDLE_HASH = Animator.StringToHash("Idle");

    public int currentHealth;
    // private Knockback knockback;
    // private Flash flash;

    // private void Awake()
    // {
    //     flash = GetComponent<Flash>();
    //     knockback = GetComponent<Knockback>();
    // }


    private void Awake() {
        imageBoxManager= FindObjectOfType<AltavozBoxManager>();
        nameBoxManager=FindObjectOfType<NameBoxManager>();
        animator = GetComponent<Animator>();
        enemyHuman = GetComponent<EnemyHuman>();
        itemText = GetComponentInChildren<ItemText>();
        textBoxManager= FindObjectOfType<TextBoxManager>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        unlockDoor= FindObjectOfType<UnlockDoor>();
        if(unlockDoor!=null)
        {
            unlockDoor.kills++;
        }
        
        currentHealth -= damage;
        if(id==1)
            {
                imageBoxManager.Enable();
                nameBoxManager.text(2,2);
                textBoxManager.text(5,5);
            }
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
            if(id==2)
            {
                imageBoxManager.Enable();
                nameBoxManager.text(2,2);
                textBoxManager.text(9,9);
            }

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

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}