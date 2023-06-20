using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertCave : MonoBehaviour
{
    private TextBoxManager textBoxManager;
    private NameBoxManager nameBoxManager;
    private AltavozBoxManager altavozBoxManager;
    
    
    void Start()
    {
        altavozBoxManager= FindObjectOfType<AltavozBoxManager>();
        textBoxManager = FindObjectOfType<TextBoxManager>();
        nameBoxManager=FindObjectOfType<NameBoxManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            altavozBoxManager.Enable();
            nameBoxManager.text(3,3);
            textBoxManager.text(22,22); 
            gameObject.SetActive(false);
            //altavozBoxManager.Disable();
        }
    }
}
