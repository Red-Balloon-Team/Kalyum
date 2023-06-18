using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCType : MonoBehaviour
{
    [SerializeField] public int id;
    // Start is called before the first frame update
    private Animator animator;
    private TextBoxManager textBoxManager;
    private ItemText itemText;
    private PlayerControls playerControls;
    public bool isNear=false;
    
    public bool isTalking = false;

    //readonly int OPEN_HASH = Animator.StringToHash("Open");

    private void Awake()
    {
        textBoxManager= FindObjectOfType<TextBoxManager>();
        itemText= GetComponent<ItemText>();
        //animator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        playerControls.Inventory.CollectItem.performed += ctx => InitConvers();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void InitConvers()
    {
        if (!isTalking && isNear)
        {
            if(id==2)
            {
                textBoxManager.text(1,3);
                itemText.HidePrompt();
                isTalking=true;
            }
            //animator.SetTrigger(OPEN_HASH);
            
        }
    }
}


