using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Password : MonoBehaviour
{
    private string password = "4781";
    private string input = null;
    private int index = 0;
    public TMP_Text UiText = null;
    public bool correct = false;

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
