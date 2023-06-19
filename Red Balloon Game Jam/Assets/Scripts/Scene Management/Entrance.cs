using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [SerializeField] private string transitionName;

    // private PlayerController playerController;

    // private void Awake() {
    //     playerController = FindObjectOfType<PlayerController>();
    // }

    private void Start()
    {
        if (transitionName == SceneManagement.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            Fade.Instance.FadeToClear();
        }

    }
}

