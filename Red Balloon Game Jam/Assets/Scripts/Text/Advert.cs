using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertCave : MonoBehaviour
{
    [SerializeField] public int id;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;
    private AltavozBoxManager altavozBoxManager;
    private InventorySlot inventorySlot;
    private Cave cave;
    private ItemCollector itemCollector;
    private bool isDinamiteInInventory; // Variable para comprobar si el ítem "dinamita" está en el inventario

    void Start()
    {
        altavozBoxManager = FindObjectOfType<AltavozBoxManager>();
        textBoxManager = FindObjectOfType<TextBoxManager>();
        nameBoxManager = FindObjectOfType<NameBoxManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (id == 0)
            {
                itemCollector = FindObjectOfType<ItemCollector>();
                
                isDinamiteInInventory = itemCollector.weaponInfo.isInInventory && itemCollector.weaponInfo.weaponName == "Dinamita";

                Debug.Log(isDinamiteInInventory);
                Debug.Log(itemCollector.weaponInfo.weaponName);
                Debug.Log(itemCollector.weaponInfo.isInInventory);

                if (isDinamiteInInventory)
                {
                    cave = FindObjectOfType<Cave>();
                    cave.OpenDoor();
                }
                else
                {
                    altavozBoxManager.Enable();
                    nameBoxManager.text(3, 3);
                    textBoxManager.text(22, 22);
                    //gameObject.SetActive(false);
                }
            }
            else if (id == 1)
            {
                altavozBoxManager.Enable();
                nameBoxManager.text(3, 3);
                textBoxManager.text(24, 24);
                gameObject.SetActive(false);
            }
            else if (id == 2)
            {
                altavozBoxManager.Enable();
                nameBoxManager.text(3, 3);
                textBoxManager.text(25, 25);
                gameObject.SetActive(false);
            }
            else if (id == 3)
            {
                itemCollector = FindObjectOfType<ItemCollector>();
                
                isDinamiteInInventory = itemCollector.weaponInfo.isInInventory && itemCollector.weaponInfo.weaponName == "Tarjeta";

                Debug.Log(isDinamiteInInventory);
                Debug.Log(itemCollector.weaponInfo.weaponName);
                Debug.Log(itemCollector.weaponInfo.isInInventory);

                if (isDinamiteInInventory)
                {
                    cave = FindObjectOfType<Cave>();
                    cave.OpenDoor();
                }
                else
                {
                    altavozBoxManager.Enable();
                    nameBoxManager.text(3, 3);
                    textBoxManager.text(22, 22);
                    //gameObject.SetActive(false);
                }
            }
        }
    }
}
