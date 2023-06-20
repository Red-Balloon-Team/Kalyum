using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public int kills=0;
    public int saved=0;
    private Timer timer;    
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
