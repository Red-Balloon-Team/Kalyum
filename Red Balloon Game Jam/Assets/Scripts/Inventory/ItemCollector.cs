using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private WeaponInfo weaponInfo;
    private ItemText pickupPrompt;
    private NPCType nPCType;
    private Door door;
    private bool notObject= true;

    private PlayerControls playerControls;
    public GameObject currentItem;
    private ActiveInventory activeInventory;

    private void Awake()
    {
        door= FindObjectOfType<Door>();
        nPCType= FindObjectOfType<NPCType>();
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
        if (currentItem != null && !notObject)
        {
            if (weaponInfo != null)
            {
                weaponInfo.isInInventory = true;
                activeInventory.ActivateInventorySlot(weaponInfo.weaponIndex);
                if(activeInventory.activeSlotIndexNum == weaponInfo.weaponIndex)
                {
                    activeInventory.ToggleActiveHighlight(weaponInfo.weaponIndex);
                }
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
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.ShowPrompt(weaponInfo.weaponName);
            currentItem = collision.gameObject;
            notObject=false;
        }
        if(collision.CompareTag("NPC"))
        {
            pickupPrompt=collision.GetComponentInChildren<ItemText>();
            pickupPrompt.NPCPrompt();
            currentItem = collision.gameObject;
            nPCType.isNear=true;
            notObject=true;
        }
        if(collision.CompareTag("Door"))
        {
            pickupPrompt=collision.GetComponentInChildren<ItemText>();
            pickupPrompt.DoorPrompt();
            currentItem = collision.gameObject;
            door.isNear=true;
            notObject=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
            nPCType.isNear=false;
            door.isNear=false;
        }
    }
}
