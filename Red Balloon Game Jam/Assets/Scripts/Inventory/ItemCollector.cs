using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    private ItemText pickupPrompt;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;

    private PlayerControls playerControls;
    private GameObject currentItem;
    private ActiveInventory activeInventory;
    private AltavozBoxManager imageBoxManager;

    private void Awake()
    {
        imageBoxManager= FindObjectOfType<AltavozBoxManager>();
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
                Debug.Log(weaponInfo.weaponIndex);
                weaponInfo.isInInventory = true;
                activeInventory.ActivateInventorySlot(weaponInfo.weaponIndex);
                activeInventory.ToggleActiveHighlight(weaponInfo.weaponIndex);
                Destroy(currentItem);
                currentItem = null;
                if(weaponInfo.weaponName=="Pistola")
                {
                    imageBoxManager.Enable();
                    nameBoxManager.text(2,2);
                    textBoxManager.text(3,4);
                }
                if(weaponInfo.weaponName=="Tasser")
                {
                    imageBoxManager.Enable();
                    nameBoxManager.text(2,2);
                    textBoxManager.text(6,8);
                }
                if (weaponInfo.weaponName == "Dinamita")
                {
                    imageBoxManager.Enable();
                    nameBoxManager.text(2,2);
                    textBoxManager.text(23,23);
                }
                if (weaponInfo.weaponName == "Tarjeta")
                {
                    imageBoxManager.Enable();
                    nameBoxManager.text(2,2);
                    textBoxManager.text(26,26);
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