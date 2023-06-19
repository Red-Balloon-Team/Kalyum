using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private WeaponInfo weaponInfo;
    private ItemText pickupPrompt;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;

    private PlayerControls playerControls;
    private GameObject currentItem;
    private ActiveInventory activeInventory;

    private void Awake()
    {
        nameBoxManager=FindObjectOfType<NameBoxManager>();
        textBoxManager= FindObjectOfType<TextBoxManager>();
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
                activeInventory.ToggleActiveHighlight(weaponInfo.weaponIndex);
                Destroy(currentItem);
                currentItem = null;
                if(weaponInfo.weaponName=="Pistol")
                {
                    nameBoxManager.text(2,2);
                    textBoxManager.text(3,4);
                }
                if(weaponInfo.weaponName=="Tasser")
                {
                    nameBoxManager.text(2,2);
                    textBoxManager.text(6,8);
                }
                
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
        }
    }
}