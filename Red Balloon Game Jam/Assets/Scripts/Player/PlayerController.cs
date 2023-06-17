using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    // private void OnDisable() {
    //     playerControls.Disable();
    // }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        FaceingDirection();
        Move();
    }

    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void FaceingDirection() {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (mousePosition.x < playerScreenPoint.x) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }
}
