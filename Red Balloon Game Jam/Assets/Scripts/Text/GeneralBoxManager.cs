using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBoxManager : MonoBehaviour
{
 public GameObject imageBox;
    
    public void Enable(){
        imageBox.SetActive(true);
    }
    public void Disable()
    {
        imageBox.SetActive(false);
    }
}
