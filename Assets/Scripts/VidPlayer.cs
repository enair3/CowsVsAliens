using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VidPlayer : MonoBehaviour
{
	[SerializeField] string videoFileName;
	public VideoPlayer vidPlayer;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
		vidPlayer.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void PlayVideo()
	{
		VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
		
		if (videoPlayer)
		{
			string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
			Debug.Log(videoPath);
			videoPlayer.url = videoPath;
			videoPlayer.Play();
		}
	}
	 void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("HowToPlay");
    }
	
}