using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBegining : MonoBehaviour
{
    //GameObject gameObject;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private Timer timer;
    private float waitToLoadTime = 1f;
    private void Awake()
    {
        timer=FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(timer.finish){
            if (other.gameObject.GetComponent<PlayerController>())
            {
                SceneManagement.Instance.SetTransitionName(sceneTransitionName);
                Fade.Instance.FadeToBlack();
                StartCoroutine(LoadSceneRoutine());
            }
        }
        timer.finish=false;
        timer.currentTime=10;
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
