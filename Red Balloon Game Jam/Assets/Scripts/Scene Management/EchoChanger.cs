using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EchoChanger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    private float waitToLoadTime = 1f;

    public void EchoChangeScene()
    {
        SceneManagement.Instance.SetTransitionName(sceneTransitionName);
        Fade.Instance.FadeToBlack();
        StartCoroutine(LoadSceneRoutine());

    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0f)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
