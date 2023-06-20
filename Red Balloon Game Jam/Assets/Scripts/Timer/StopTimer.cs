using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    
    private Timer timer;
    // Start is called before the first frame update
    private void Start()
    {
        timer=FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            timer.stop();
        }
    }
    

    
        
    
    
        
    
    // Update is called once per frame
    
}
