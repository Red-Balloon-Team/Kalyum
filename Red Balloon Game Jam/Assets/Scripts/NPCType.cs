using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCType : MonoBehaviour
{
    [SerializeField] public int id;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;
    private Timer timer;
    private Door door;
    private ItemText itemText;
    private bool isTalking = false;
    //private bool success=false;

    private void Awake()
    {
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
            if (id == 2)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(12, 13);
                itemText.HidePrompt();
                isTalking = true;
            }
            if(id==3 && !timer.finish)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(15, 16);
                door.unlock=true;
                Debug.Log(door.unlock);

            }
            if(id==3 && timer.finish)
            {
                nameBoxManager.text(0,0);
                textBoxManager.text(14, 14);
            }
        }
    }    
}
