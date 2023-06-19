using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCType : MonoBehaviour
{
    [SerializeField] public int id;
    private TextBoxManager textBoxManager;
    private ItemText itemText;
    private bool isTalking = false;

    private void Awake()
    {
        textBoxManager = FindObjectOfType<TextBoxManager>();
        itemText = GetComponent<ItemText>();
    }

    public void InitConvers()
    {
        if (!isTalking)
        {
            if (id == 2)
            {
                textBoxManager.text(0, 2);
                itemText.HidePrompt();
                isTalking = true;
            }
        }
    }
}
