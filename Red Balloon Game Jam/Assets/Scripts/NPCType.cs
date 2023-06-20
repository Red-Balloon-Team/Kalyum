using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCType : MonoBehaviour
{
    [SerializeField] public int id;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;
    private AltavozBoxManager imageBoxManager;
    private EvelynBoxManager evelynBoxManager;
    private GeneralBoxManager generalBoxManager;
    private Timer timer;
    private Door door;
    private ItemText itemText;
    private bool isTalking = false;
    public bool hasTalked=false;
    //private bool success=false;

    private void Awake()
    {
        imageBoxManager= FindObjectOfType<AltavozBoxManager>();
        evelynBoxManager= FindObjectOfType<EvelynBoxManager>();
        generalBoxManager= FindObjectOfType<GeneralBoxManager>();
        door= FindObjectOfType<Door>();
        timer=FindObjectOfType<Timer>();
        nameBoxManager=FindObjectOfType<NameBoxManager>();
        textBoxManager = FindObjectOfType<TextBoxManager>();
        itemText = GetComponent<ItemText>();
    }
    public void InitConvers()
    {
        if (!isTalking)
        {
            if (id == 2 && !hasTalked)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(12, 13);
                itemText.HidePrompt();
                isTalking = true;
                hasTalked=true;
                generalBoxManager.Enable();
            }
            if(id==3 && !timer.finish && !hasTalked)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(15, 16);
                door.unlock=true;
                itemText.HidePrompt();
                isTalking = true;
                hasTalked=true;
                generalBoxManager.Enable();
                timer.DisableTimer();
                //Debug.Log(door.unlock);

            }
            if(id==3 && timer.finish && !hasTalked)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(14, 14);
                itemText.HidePrompt();
                isTalking = true;
                hasTalked=true;
                generalBoxManager.Enable();
                timer.DisableTimer();
            }
            if(id==4 && !hasTalked){
                nameBoxManager.text(1,1);
                textBoxManager.text(17, 21);
                itemText.HidePrompt();
                isTalking = true;
                hasTalked=true;
                evelynBoxManager.Enable();
            }
        }
        isTalking=false;
        //hasTalked=false;
    }
        
}
