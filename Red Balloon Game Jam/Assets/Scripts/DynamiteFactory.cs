using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteFactory : MonoBehaviour
{
    private Animator animator;
    public bool stop = false;
    public bool start = false;
    private Transform dynamite;
    public float distance = 6f;
    public float velocity = 2f;
    private bool createDynamite = false;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    readonly int PRESS_HASH = Animator.StringToHash("pressed");
    readonly int IDLE_HASH = Animator.StringToHash("idle");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        dynamite = transform.GetChild(0);
    }

    private void Start()
    {
        initialPosition = dynamite.position;
        finalPosition = initialPosition + Vector3.left * distance;
        dynamite.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (createDynamite && dynamite != null)
        {
            Vector3 movement = Vector3.left * velocity * Time.deltaTime;
            dynamite.Translate(movement);

            if (Vector3.Distance(dynamite.position, initialPosition) >= distance)
            {
                createDynamite = false;
            }
            else if (Vector3.Distance(dynamite.position, initialPosition) <= distance && !stop)
            {
                StopMovement();
            }
        }
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

    public void CreateDynamite()
    {
        dynamite.gameObject.SetActive(true);
        createDynamite = true;
        dynamite.position = initialPosition;
    }
}

