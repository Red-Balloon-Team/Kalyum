using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertCave : MonoBehaviour
{
    [SerializeField]public int id;
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
            if(id==0)
            {
                altavozBoxManager.Enable();
                nameBoxManager.text(3,3);
                textBoxManager.text(22,22); 
                gameObject.SetActive(false);
            }
            if(id==1)
            {
                altavozBoxManager.Enable();
                nameBoxManager.text(3,3);
                textBoxManager.text(24,24); 
                gameObject.SetActive(false);
            }
            if(id==2)
            {
                altavozBoxManager.Enable();
                nameBoxManager.text(3,3);
                textBoxManager.text(25,25); 
                gameObject.SetActive(false);
            }
        }
    }
}
