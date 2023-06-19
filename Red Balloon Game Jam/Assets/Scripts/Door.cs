using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int id=0;
    private Collider2D[] colliders;
    private Animator animator;
    private ItemText itemText;
    private bool isOpen = false;
    public bool unlock= false;

    readonly int OPEN_HASH = Animator.StringToHash("Open");

    private void Awake()
    {
        itemText = GetComponent<ItemText>();
        colliders = GetComponentsInChildren<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if ((!isOpen && id!=1)||(id==1 && !isOpen && unlock))
        {
            animator.SetTrigger(OPEN_HASH);
            isOpen = true;
            itemText.HidePrompt();
        }
    }

    private void DestroyColliders()
    {
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider);
        }
    }
}
