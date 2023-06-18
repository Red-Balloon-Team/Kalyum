using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemText : MonoBehaviour
{
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

    public void HidePrompt()
    {
        canvas.gameObject.SetActive(false);
    }
}


