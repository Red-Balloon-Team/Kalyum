using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;//  la linea actual
    public int endAtLine;// la linea donde acaba
    public PlayerController player;// para deactivar el movimiento del player cuando salga texto (si lo hacemos)
    // Start is called before the first frame update
    void Start()
    {
        player= FindObjectOfType<PlayerController>();
        if(textFile!=null)
        {
            textLines=(textFile.text.Split('\n'));
        }  
    }

    void Update()
    {
        theText.text=textLines[currentLine];
        if(Input.GetKeyDown(KeyCode.Return))
        {
            currentLine+=1;
        }
        if(currentLine>endAtLine)
        {
            textBox.SetActive(false);
        }
    }
}
