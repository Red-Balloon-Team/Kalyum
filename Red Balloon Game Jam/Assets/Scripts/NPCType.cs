using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCType : MonoBehaviour
{
    [SerializeField] public int id;
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;
    private ItemText itemText;
    private bool isTalking = false;

    private void Awake()
    {
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
                nameBoxManager.text(1,1);
                textBoxManager.text(0, 2);
                itemText.HidePrompt();
                isTalking = true;
            }
        }
    }
}
