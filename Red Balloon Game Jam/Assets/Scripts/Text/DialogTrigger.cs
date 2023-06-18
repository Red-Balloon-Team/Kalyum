using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public NPC[] actors;
}
[System.Serializable]
public class NPC
{
    public int name;
    //public Sprite sprite;
}
[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}