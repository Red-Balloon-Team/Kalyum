using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : MonoBehaviour
{
    private Animator animator;
    private PlayerControls playerControls;
    private EnemyHealth enemyHealth;
    public bool isStunned = false;

    readonly int SAVED_HASH = Animator.StringToHash("Saved");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        enemyHealth = GetComponent<EnemyHealth>();
        playerControls.Inventory.CollectItem.performed += ctx => TakeVision();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void TakeVision()
    {
        if (isStunned)
        {
            animator.SetTrigger(SAVED_HASH);
            enemyHealth.isStunned = false;
        }
    }
}
