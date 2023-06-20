using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltavozBoxManager : MonoBehaviour
{ 
    public bool isActive;
    public GameObject imageBox;
    
    public void Enable(){
        imageBox.SetActive(true);
        isActive=true;
    }
    public void Disable()
    {
        imageBox.SetActive(false);
        isActive=false;
    }
    

}
