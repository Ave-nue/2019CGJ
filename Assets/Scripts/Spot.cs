using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    Vector3 hsv = new Vector3(0, 1, 1);
    Light spot;
    void Start()
    {
        spot = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        hsv.x += 0.05f;
        //Color.RGBToHSV(spot.color, out hsv.x, out hsv.y, out hsv.z);
        spot.color = Color.HSVToRGB(((hsv.x * 360f) % 360) / 360, 1, 1);
    }
}
