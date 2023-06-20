using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;
    public Canvas canvas;
    private string password = "4781";
    private string input = null;
    private int index = 0;
    public TMP_Text UiText = null;
    public bool correct = false;
    private LightEffect lightEffect;

    public void ActiveNumPad()
    {
        gameObject.SetActive(true);
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
        if (input == password)
        {
            correct = true;
            light2D = FindObjectOfType<UnityEngine.Rendering.Universal.Light2D>();
            light2D.intensity = 1f;
            gameObject.SetActive(false);
            lightEffect = FindObjectOfType<LightEffect>();
            lightEffect.gameObject.SetActive(false);
        }
        else
        {
            DeleteCode();
        }
    }

    public void DeleteCode()
    {
        index = 0;
        input = null;
        UiText.text = input;
    }
}
