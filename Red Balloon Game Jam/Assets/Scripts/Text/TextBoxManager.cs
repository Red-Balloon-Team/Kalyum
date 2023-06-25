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
    private AltavozBoxManager imageBoxManager;
    private EvelynBoxManager evelynBoxManager;
    private GeneralBoxManager generalBoxManager;

    public int control=0;
    
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    private bool isTyping;
    public bool textEnabled;
    private bool cancelTyping;

    private Coroutine typingCoroutine;

    public void Start()
    {

        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        imageBoxManager= FindObjectOfType<AltavozBoxManager>();
        evelynBoxManager=FindObjectOfType<EvelynBoxManager>();
        generalBoxManager= FindObjectOfType<GeneralBoxManager>();
        imageBoxManager.Enable();
        text(0,2);
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
            textEnabled = false;
            if(imageBoxManager.isActive)
            {
                imageBoxManager.Disable();
            }
            else if(evelynBoxManager.isActive)
            {
                evelynBoxManager.Disable();
            }
            else if(generalBoxManager.isActive)
            {
                generalBoxManager.Disable();
            }
            control=1;
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

    public void text(int start, int finish){
        textBox.SetActive(true);
        textEnabled = true;
        currentLine=start-1;
        endAtLine=finish;       
        ShowNextLine();
       
    }
}
