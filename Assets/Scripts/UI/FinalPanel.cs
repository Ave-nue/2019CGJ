using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPanel : MonoBehaviour
{
    public Image win_img;
    public GameObject win_btn;
    public GameObject fail_text;
    public GameObject fail_btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(bool isWin)
    {
        win_img.enabled = isWin;
        win_btn.SetActive(isWin);
        fail_text.SetActive(!isWin);
        fail_btn.SetActive(!isWin);

        if (isWin)
            SoundMgr.Instance().PlaySoundEffect(4);
        else
            SoundMgr.Instance().PlaySoundEffect(0);

    }
}
