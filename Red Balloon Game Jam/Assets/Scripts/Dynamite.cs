using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public GameObject dynamite;
    public float distance = 10f;
    public float velocity = 10f;
    private bool createDynamite = false;
    private Vector3 initialPisition;
    private Vector3 finalPosition;

    private void Start()
    {
        initialPisition = dynamite.transform.position;
        finalPosition = initialPisition + Vector3.left * distance;
    }

    private void Update()
    {
        if (createDynamite)
        {
            Vector3 movimiento = Vector3.left * velocity * Time.deltaTime;
            dynamite.transform.Translate(movimiento);

            if (Vector3.Distance(dynamite.transform.position, initialPisition) >= distance)
            {
                createDynamite = false;
            }
        }
    }

    public void CreateDynamite()
    {
        dynamite.SetActive(true);
        createDynamite = true;
        dynamite.transform.position = initialPisition;
    }
}


