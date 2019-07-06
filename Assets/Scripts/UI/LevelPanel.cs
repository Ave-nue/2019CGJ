using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelPanel : MonoBehaviour
{
    public double bottomTime;
    public float shake_range = 0.1f;

    public GameObject pausePanel;
    public Animator animator;

    public static LevelPanel levelPanel;

    private double m_targetTick;
    private Transform m_shakeTr;
    private Vector3 shakePos;


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                OnBackBtn();
            }
            else
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }

        if (m_shakeTr != null)
        {
            if (Time.timeScale != 1 && GetTick() >= m_targetTick)
            {
                Time.timeScale = 1;
                m_shakeTr = null;
            }
            else if (Time.timeScale == 0)
            {
                Vector3 newPos = UnityEngine.Random.insideUnitCircle * shake_range;
                m_shakeTr.SetPositionAndRotation(shakePos + newPos, Quaternion.identity);
            }
        }
    }

    public void OnBack2StartBtn()
    {
        OnBackBtn();
        SceneManager.LoadScene("Start Scene");
        levelPanel.gameObject.SetActive(false);
    }

    public void OnBackBtn()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("game over");
    }

    public void BottomFrame()
    {
        Debug.Log("shake");
        Time.timeScale = 0;
        m_targetTick = GetTick() + bottomTime;
    }

    double GetTick()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        return timeSpan.TotalSeconds;
    }

    public void ShakeObj(Transform objTr)
    {
        m_shakeTr = objTr;
        shakePos = objTr.position;
    }

    public void WarePant()
    {
        animator.Play("Ware");
    }
}
