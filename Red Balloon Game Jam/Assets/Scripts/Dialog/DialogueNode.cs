using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
   [SerializeField]private string name; 
   [SerializeField]private string parent;
   [SerializeField]private string answer;
   [SerializeField]private string text;

   public string Name{get=> name; set=> name= value;}
   public string Parent{get=> parent; set=> parent= value;}
   public string Answer{get=> answer; set=> answer= value;}
   public string Text{get=> text; set=> text= value;}
   
}

