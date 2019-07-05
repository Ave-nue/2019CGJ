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
        LevelPanel.levelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartBtn()
    {
        SceneManager.LoadScene("Level 1");
        LevelPanel.levelPanel.SetActive(true);
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}
