using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    private ItemText pickupPrompt;
    private NPCType nPCType;
    private Timer timer;
    private List<Door> doorsInRange = new List<Door>();
    private List<NPCType> npcInRange= new List<NPCType>();
    public GameObject currentItem;

    private bool interactingWithNPC = false;
    private bool interactingWithButton = false;

    private PlayerControls playerControls;

    private void Awake()
    {
        timer=FindObjectOfType<Timer>();
        nPCType = FindObjectOfType<NPCType>();
        playerControls = new PlayerControls();
        playerControls.Inventory.CollectItem.performed += ctx => Interact();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            weaponInfo = collision.GetComponent<Pickup>().GetWeaponInfo();
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.ShowPrompt(weaponInfo.weaponName);
            currentItem = collision.gameObject;
            interactingWithNPC = false;
            interactingWithButton=false;
        }
        else if (collision.CompareTag("NPC"))
        {
            NPCType nPCType= collision.GetComponent<NPCType>();
            npcInRange.Add(nPCType);
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.NPCPrompt();
            currentItem = collision.gameObject;
            interactingWithNPC = true;
            interactingWithButton=false;
        }
        else if (collision.CompareTag("Door"))
        {
            Door door = collision.GetComponent<Door>();
            doorsInRange.Add(door);
            pickupPrompt = door.GetComponentInChildren<ItemText>();
            pickupPrompt.DoorPrompt();
        }
        else if (collision.CompareTag("Button"))
        {
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.ButtonPrompt();
            currentItem = collision.gameObject;
            interactingWithButton = true;
            interactingWithNPC=false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
            interactingWithNPC = false;
        }
        else if (collision.CompareTag("Door"))
        {
            Door door = collision.GetComponent<Door>();
            pickupPrompt.HidePrompt();
            doorsInRange.Remove(door);
        }
        else if (collision.CompareTag("NPC"))
        {
            NPCType nPCType = collision.GetComponent<NPCType>();
            pickupPrompt.HidePrompt();
            npcInRange.Remove(nPCType);
        }
    }

    private void Interact()
    {
        if (npcInRange.Count>0)
        {
            NPCType nPCType= GetClosestNPC();
            nPCType.InitConvers();
        }
        else if(interactingWithButton)
        {
            timer.EnableTimer();
        }
        else if (doorsInRange.Count > 0)
        {
            Door closestDoor = GetClosestDoor();
            closestDoor.OpenDoor();
        }
    }
    private NPCType GetClosestNPC()
    {
        NPCType closestNPC = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = transform.position;

        foreach (NPCType nPCType in npcInRange)
        {
            float distance = Vector3.Distance(playerPosition, nPCType.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNPC = nPCType;
            }
        }

        return closestNPC;
    }

    private Door GetClosestDoor()
    {
        Door closestDoor = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = transform.position;

        foreach (Door door in doorsInRange)
        {
            float distance = Vector3.Distance(playerPosition, door.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDoor = door;
            }
        }

        return closestDoor;
    }
}
