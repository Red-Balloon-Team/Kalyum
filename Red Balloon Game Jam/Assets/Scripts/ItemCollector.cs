using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfo;

    private PlayerControls playerControls;
    private GameObject currentItem;
    private ActiveInventory activeInventory;

    private void Awake()
    {
        playerControls = new PlayerControls();
        activeInventory = FindObjectOfType<ActiveInventory>();
        playerControls.Inventory.CollectItem.performed += ctx => CollectItem();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void CollectItem()
    {
        if (currentItem != null)
        {
            if (weaponInfo != null)
            {
                weaponInfo.isInInventory = true;
                activeInventory.ActivateInventorySlot(weaponInfo.weaponIndex);
                Destroy(currentItem);
                currentItem = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            weaponInfo = collision.GetComponent<Pickup>().GetWeaponInfo();
            currentItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            currentItem = null;
        }
    }
}
