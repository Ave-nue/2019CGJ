using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashColor : MonoBehaviour
{
    public Image img;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (img)
        {
            Vector3 hsv;
            Color.RGBToHSV(img.color, out hsv.x, out hsv.y, out hsv.z);
            img.color = Color.HSVToRGB(((hsv.x * 360 + 7) % 360) / 360, 1, 1);
            Color.RGBToHSV(img.color, out hsv.x, out hsv.y, out hsv.z);
        }
        if (sprite)
        {

        }
    }
}
