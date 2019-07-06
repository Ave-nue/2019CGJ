using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDirector : MonoBehaviour
{
    public int startClip;
    // Start is called before the first frame update
    void Start()
    {
        FlashPanel.flashMgr.PlayFlash(startClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
