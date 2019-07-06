using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System;

public class PlayVideo : MonoBehaviour
{
    public VideoClip[]  videoclips;
    public VideoPlayer.EventHandler endPlayHandler;

    VideoPlayer player;
    [SerializeField]
    int index=0;
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.clip = videoclips[index];
        player.Play();

        player.loopPointReached += new VideoPlayer.EventHandler(PlayNext);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            PlayNext(player);
        }
        
    }

    void PlayNext(VideoPlayer player)
    {
        if(index>=videoclips.Length-1)
        {
            //播完视频 进入主界面
            SceneManager.LoadScene("Start Scene");
        }
        else
        {
            player.clip = videoclips[index];
            player.Play();
            index++;
        }
    }

    
}
