using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Password : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;
    private string password = "4781";
    private string input = null;
    private int index = 0;
    public TMP_Text UiText = null;
    public bool correct = false;

    private void Awake()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        if (light2D == null)
        {
            Debug.Log("Light2D not found");
        }
    }

    public void EnterCode(string nums)
    {
        if (index < 4)
        {
            index++;
            input = input + nums;
            UiText.text = input;
        }
    }

    public void CheckCode()
    {
        Debug.Log(input);
        if (input == password)
        {
            correct = true;
            Debug.Log("Correct");
            light2D.intensity = 1f;
        }
        else
        {
            DeleteCode();
            Debug.Log("Incorrect");
        }
    }

    public void DeleteCode()
    {
        index = 0;
        input = null;
        UiText.text = input;
    }
}
