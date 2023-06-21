using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    private Collider2D[] colliders;
    private Animator animator;
    private ItemText itemText;
    readonly int OPEN_HASH = Animator.StringToHash("open");

    private void Awake()
    {
        itemText = GetComponent<ItemText>();
        colliders = GetComponentsInChildren<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger(OPEN_HASH);
        itemText.HidePrompt();  
    }

    private void DestroyColliders()
    {
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider);
        }
    }
}
