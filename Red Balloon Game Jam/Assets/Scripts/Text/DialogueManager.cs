using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;

    Message[] currentMessages;
    NPC[] currentNPC;
    int activeMessage=0;

    public void OpenDialogue(Message[] messages, NPC[] npc)
    {
        currentMessages= messages;
        currentNPC= npc;
        activeMessage=0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
