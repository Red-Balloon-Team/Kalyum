using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBoxManager : MonoBehaviour
{
    public GameObject imageBox;
    public bool isActive;
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
