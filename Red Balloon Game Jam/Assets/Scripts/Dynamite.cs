// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Dynamite : MonoBehaviour
// {
//     private Transform dynamite;
//     private DynamiteFactory dynamiteFactory;
//     public float distance = 6f;
//     public float velocity = 2f;
//     private bool createDynamite = false;
//     private Vector3 initialPisition;
//     private Vector3 finalPosition;


//     private void Start()
//     {
//         initialPisition = transform.position;
//         finalPosition = initialPisition + Vector3.left * distance;
//         gameObject.SetActive(false);
//     }

//     private void Update()
//     {
//         if (createDynamite)
//         {
//             Vector3 movimiento = Vector3.left * velocity * Time.deltaTime;
//             transform.Translate(movimiento);

//             if (Vector3.Distance(transform.position, initialPisition) >= distance)
//             {
//                 createDynamite = false;
//             }
//             else if (Vector3.Distance(transform.position, initialPisition) <= distance && !dynamiteFactory.stop)
//             {
//                 dynamiteFactory.StopMovement();
//             }
//         }
//     }

//     public void CreateDynamite()
//     {
//         gameObject.SetActive(true);
//         createDynamite = true;
//         transform.position = initialPisition;
//     }
// }
