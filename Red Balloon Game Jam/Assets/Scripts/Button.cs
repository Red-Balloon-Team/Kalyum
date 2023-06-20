using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    private Animator animator;
    readonly int PRESS_HASH = Animator.StringToHash("pressed");
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        animator.SetTrigger(PRESS_HASH);
    }

}
