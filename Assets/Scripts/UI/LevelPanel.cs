using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPanel : MonoBehaviour
{
    public static LevelPanel levelPanel;

    private void Awake()
    {
        if (levelPanel)
            Destroy(gameObject);
        else
            levelPanel = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBack2StartBtn()
    {
        SceneManager.LoadScene("Start Scene");
        levelPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("game over");
    }
}
