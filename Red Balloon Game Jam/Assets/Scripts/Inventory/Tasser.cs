using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasser : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private Transform weaponCollider;

    private Animator animator;
    private TextBoxManager textBoxManager;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake() {
        animator = GetComponent<Animator>();
        textBoxManager= FindObjectOfType<TextBoxManager>();
        textBoxManager.text(4,4);
    }

    public void Attack()
    {
        weaponCollider.gameObject.SetActive(true);
        animator.SetTrigger(ATTACK_HASH);
    }

    public void DesactivateTasserColliderEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

}
