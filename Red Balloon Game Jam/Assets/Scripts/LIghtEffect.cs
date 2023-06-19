using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightEffect : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.0f;
    public float changeSpeed = 1.0f;
    public float rotationSpeed = 45.0f;

    private float targetIntensity;
    private float currentIntensity;

    private void Awake() {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }
    
    private void Start()
    {
    
        currentIntensity = light2D.intensity;
        targetIntensity = maxIntensity;
    }

    private void Update()
    {
        currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, changeSpeed * Time.deltaTime);
        light2D.intensity = currentIntensity;

        if (currentIntensity >= maxIntensity || currentIntensity <= minIntensity)
        {
            targetIntensity = (targetIntensity == maxIntensity) ? minIntensity : maxIntensity;
        }

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
