using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public int kills=0;
    public int saved=0;
    public GameObject gameObject;
    private Timer timer;
    
    // Start is called before the first frame update
    
    void Update(){
        countKills();
    }

    public void countKills()
    {
        timer= FindObjectOfType<Timer>();
        if((kills==3 && saved==2)||(timer.finish==true))
        {
            unlock();
        }
    }
    public void unlock()
    {
        gameObject.SetActive(false);
    }
}
