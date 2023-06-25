using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;
    public GameObject startButton;

    private bool videoStarted = false;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
        startButton.SetActive(true);
        videoPlayer.Pause();
    }

    public void StartVideo()
    {
        if (!videoStarted)
        {
            videoPlayer.Play();
            startButton.SetActive(false);
            videoStarted = true;
        }
    }

    void OnVideoFinished(VideoPlayer player)
    {
        SceneManager.LoadScene(sceneName);
    }
}
