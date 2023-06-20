using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteFactory : MonoBehaviour
{
    private Animator animator;
    public bool stop = false;
    readonly int PRESS_HASH = Animator.StringToHash("pressed");
    readonly int IDLE_HASH = Animator.StringToHash("idle");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        animator.SetTrigger(PRESS_HASH);
    }

    public void StopMovement()
    {
        animator.SetTrigger(IDLE_HASH);
        stop = true;
    }
}
