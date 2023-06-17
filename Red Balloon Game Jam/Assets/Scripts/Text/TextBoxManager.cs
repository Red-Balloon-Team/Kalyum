using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField] public float typeSpeed;
    
    public GameObject textBox;
    public TextMeshProUGUI theText;
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;
    public PlayerController player;

    private bool isTyping;
    private bool cancelTyping;

    private Coroutine typingCoroutine;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        currentLine = -1;
        ShowNextLine();
    }

    void Update()
    {
        if (textBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isTyping)
                {
                    cancelTyping = true;
                }
                else
                {
                    ShowNextLine();
                }
            }
        }
    }

    public void ShowNextLine()
    {
        if (currentLine < endAtLine)
        {
            currentLine++;
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            typingCoroutine = StartCoroutine(TypeText(textLines[currentLine]));
        }
        else
        {
            textBox.SetActive(false);
        }
    }

    private IEnumerator TypeText(string line)
    {
        isTyping = true;
        cancelTyping = false;
        theText.text = "";

        for (int i = 0; i < line.Length; i++)
        {
            theText.text += line[i];

            if (cancelTyping)
            {
                theText.text = line;
                break;
            }

            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }
}