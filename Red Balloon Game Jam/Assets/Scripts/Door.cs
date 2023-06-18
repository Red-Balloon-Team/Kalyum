using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   Collider2D[] colliders;
    private Animator animator;
    private ItemText itemText;
    private PlayerControls playerControls;
    public bool isNear=false;
    public bool isOpen = false;

    readonly int OPEN_HASH = Animator.StringToHash("Open");

    private void Awake()
    {
        itemText= GetComponent<ItemText>();
        colliders = GetComponentsInChildren<Collider2D>();
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
        if (!isOpen && isNear)
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
