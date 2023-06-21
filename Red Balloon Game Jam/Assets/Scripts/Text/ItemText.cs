using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemText : MonoBehaviour
{
    private TextBoxManager textBoxManager;
    private NPCType nPCType;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform targetTransform;

    public void ShowPrompt(string itemName)
    {
        promptText.text = "Presiona E para recoger " + itemName;
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }

    public void EnemyHumanPrompt()
    {
        promptText.text = "Presiona E para salvar";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void DoorPrompt()
    {
        promptText.text = "Presiona E para abrir la puerta";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void NPCPrompt()
    {
        promptText.text = "Presiona E para iniciar conversación";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void ButtonPrompt()
    {
        promptText.text = "Presiona E para pulsar el botón";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void DynamitePrompt()
    {
        promptText.text = "Presiona E para crear la dinamita";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 2.0f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void CablePrompt()
    {
        promptText.text = "Presiona E para cortar el cable";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void EchoPrompt()
    {
        promptText.text = "Presiona E para cambiar de dimension";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }
    public void NumpadPrompt()
    {
        promptText.text = "Presiona E para introducir el código";
        canvas.gameObject.SetActive(true);

        Vector3 targetPosition = targetTransform.position;
        Vector3 promptPosition = new Vector3(targetPosition.x - 0.2f, targetPosition.y + 1.5f, targetPosition.z);
        promptText.rectTransform.position = promptPosition;
    }

    public void HidePrompt()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}


