using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    private ItemText pickupPrompt;
    private NPCType nPCType;
    private Timer timer;
    private Password password;
    private List<Door> doorsInRange = new List<Door>();
    private List<NPCType> npcInRange= new List<NPCType>();
    private List<EchoChanger> echoInRange = new List<EchoChanger>();
    private List<Button> buttonInRange = new List<Button>();
    public GameObject currentItem;
    private DynamiteFactory dynamiteFactory;

    private bool interactingWithButton = false;
    private bool interactingWithDynamite = false;
    private bool interactingWithNumpad = false;

    private PlayerControls playerControls;
    private Button button;

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
        if (collision.CompareTag("NPC"))
        {
            NPCType nPCType= collision.GetComponent<NPCType>();
            npcInRange.Add(nPCType);
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.NPCPrompt();
            // currentItem = collision.gameObject;
            interactingWithButton=false;
        }
        if (collision.CompareTag("Numpad"))
        {
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.NumpadPrompt();
            currentItem = collision.gameObject;
            interactingWithNumpad = true;

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
            interactingWithDynamite = false;
        }
        else if (collision.CompareTag("DynamiteFactory"))
        {
            pickupPrompt = collision.GetComponentInChildren<ItemText>();
            pickupPrompt.DynamitePrompt();
            currentItem = collision.gameObject;
            interactingWithButton = false;
            interactingWithDynamite = true;
        }
        else if (collision.CompareTag("Echo"))
        {
            EchoChanger echoChanger = collision.GetComponent<EchoChanger>();
            echoInRange.Add(echoChanger);
            pickupPrompt = echoChanger.GetComponentInChildren<ItemText>();
            pickupPrompt.EchoPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
        }
        else if (collision.CompareTag("DynamiteFactory"))
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
        }
        else if (collision.CompareTag("Numpad"))
        {
            pickupPrompt.HidePrompt();
            currentItem = null;
        }
        else if (collision.CompareTag("Door"))
        {
            Door door = collision.GetComponent<Door>();
            pickupPrompt.HidePrompt();
            doorsInRange.Remove(door);
        }
        else if (collision.CompareTag("Echo"))
        {
            EchoChanger echoChanger = collision.GetComponent<EchoChanger>();
            pickupPrompt.HidePrompt();
            echoInRange.Remove(echoChanger);
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
            if(!nPCType.hasTalked){
                nPCType.InitConvers();
            }
            nPCType.hasTalked=true;
        }
        else if (interactingWithButton)
        {
            timer.EnableTimer();
            button = FindObjectOfType<Button>();
            button.PressButton();
            timer.currentTime=40;
            timer.stopCounting=false;
        }
        else if (interactingWithNumpad)
        {
            password = FindObjectOfType<Password>();
            password.ActiveNumPad();
        }
        else if(interactingWithDynamite)
        {
            dynamiteFactory = FindObjectOfType<DynamiteFactory>();
            dynamiteFactory.PressButton();
            dynamiteFactory.CreateDynamite();
        }
        else if (doorsInRange.Count > 0)
        {
            Door closestDoor = GetClosestDoor();
            closestDoor.OpenDoor();
        }
        else if (echoInRange.Count > 0)
        {
            EchoChanger closestEcho = GetClosestEcho();
            closestEcho.EchoChangeScene();
        }
        interactingWithButton=false;
        interactingWithNumpad = false;
        interactingWithDynamite = false;
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
    private Button GetClosestButton()
    {
        Button closestButton = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = transform.position;

        foreach (Button buton in buttonInRange)
        {
            float distance = Vector3.Distance(playerPosition, button.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestButton = button;
            }
        }

        return closestButton;
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

    private EchoChanger GetClosestEcho()
    {
        EchoChanger closestEcho = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = transform.position;

        foreach (EchoChanger echoChanger in echoInRange)
        {
            float distance = Vector3.Distance(playerPosition, echoChanger.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEcho = echoChanger;
            }
        }

        return closestEcho;
    }
}
