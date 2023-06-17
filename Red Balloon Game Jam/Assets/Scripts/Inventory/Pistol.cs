using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    private Animator animator;
    private PlayerController playerController;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        animator = GetComponent<Animator>();
        animator.SetTrigger(ATTACK_HASH);
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y - playerScreenPoint.y, mousePos.x - playerScreenPoint.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            Debug.Log("Mouse is to the left of the player.");
            transform.rotation = Quaternion.Euler(0, 180, -angle);
        }
        else
        {
            Debug.Log("Mouse is to the right of the player.");
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}


