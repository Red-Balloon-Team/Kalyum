using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : MonoBehaviour
{
    private Animator animator;
    private PlayerControls playerControls;
    private TextBoxManager textBoxManager;
    private EnemyHealth enemyHealth;
    public bool isStunned = false;

    readonly int SAVED_HASH = Animator.StringToHash("Saved");//detecta si la animacion y pongo el trigger de la animacions

    private void Awake()
    {
        animator = GetComponent<Animator>();
        textBoxManager= FindObjectOfType<TextBoxManager>();
        playerControls = new PlayerControls();//detecta teclas
        enemyHealth = GetComponent<EnemyHealth>();//accede enemies
        playerControls.Inventory.CollectItem.performed += ctx => TakeVision();//detecta la tecla e
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void TakeVision()//poner open door
    {
        if (isStunned)
        {
            animator.SetTrigger(SAVED_HASH);//open_hash
            enemyHealth.isStunned = false;
            if(enemyHealth.id==2)
            {
                textBoxManager.text(10,11);
            }
        }
    }
}
