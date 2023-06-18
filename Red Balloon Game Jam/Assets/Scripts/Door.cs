using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   Collider2D[] colliders;
    private Animator animator;
    private ItemText itemText;
    private PlayerControls playerControls;
    
    public bool isOpen = false;

    readonly int OPEN_HASH = Animator.StringToHash("Open");

    private void Awake()
    {
        colliders = GetComponentsInChildren<Collider2D>();
        itemText= GetComponent<ItemText>();
        animator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        playerControls.Inventory.CollectItem.performed += ctx => OpenDoor();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            animator.SetTrigger(OPEN_HASH);
            isOpen=true;
            itemText.HidePrompt();
        }
    }
    private void DestroyColliders()
    {
        foreach(Collider2D collider in colliders)
        {
            Destroy(collider);
        }
    }
}
