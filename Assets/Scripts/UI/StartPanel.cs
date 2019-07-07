using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelPanel.levelPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartBtn()
    {
        SceneManager.LoadScene("Level 1");
        LevelPanel.levelPanel.gameObject.SetActive(true);
        SoundMgr.Instance().PlaySoundEffect(1);
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}
