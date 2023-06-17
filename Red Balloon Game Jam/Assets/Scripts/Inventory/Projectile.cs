using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private void Update() {
        moveProjectile();
    }

    private void moveProjectile() {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
