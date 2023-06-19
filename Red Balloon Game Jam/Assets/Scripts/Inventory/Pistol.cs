using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform bulletSpawnPointFlip;
    private Animator animator;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    { 
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        animator.SetTrigger(ATTACK_HASH);
        if(!spriteRenderer.flipY)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        }
        else {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPointFlip.position, transform.rotation);
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);
        if (mousePosition.x < playerScreenPoint.x - 10)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}


