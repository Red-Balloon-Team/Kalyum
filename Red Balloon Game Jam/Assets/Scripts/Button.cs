using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Collider2D[] colliders;
    private Animator animator;
    private ItemText itemText;
    private bool isOpen = false;

    readonly int PRESS_HASH = Animator.StringToHash("Pressed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        animator.SetTrigger(PRESS_HASH);
    }

}
