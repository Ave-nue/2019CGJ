using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioTeam
{
    public string teamName;
    public AudioClip[] audioClips;
}

public class SoundMgr : MonoBehaviour
{
    private static SoundMgr m_instance;
    public static SoundMgr Instance()
    {
        if (m_instance == null)
            m_instance = new SoundMgr();
        return m_instance;
    }

    [SerializeField]
    public AudioTeam[] audioClips;

    private AudioSource[] m_audioSources;
    private int m_curSourceIndex;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(int teamIndex)
    {
        m_curSourceIndex = (m_curSourceIndex + 1) % m_audioSources.Length;
        int clipIndex = Random.Range(0, audioClips[teamIndex].audioClips.Length);
        m_audioSources[m_curSourceIndex].clip = audioClips[teamIndex].audioClips[clipIndex];
        m_audioSources[m_curSourceIndex].Play();
    }
}
