using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{

    public GameObject daylight;
    public GameObject nightlight;

    public Vector3 day_change;
    public Vector3 night_change;

    public GameObject player;
    public GameObject spot;

    public Vector3 day_end_rotation;
    public Vector3 night_end_rotation;

    public int steps = 100;

    void Start()
    {
        daylight = GameObject.Find("DayLight");
        nightlight = GameObject.Find("NightLight");

        player = GameObject.Find("Player");
        spot = player.transform.GetChild(2).gameObject;

        day_change = day_end_rotation - daylight.transform.rotation.eulerAngles; 
        night_change = night_end_rotation - nightlight.transform.rotation.eulerAngles;
        day_change /= steps;
        night_change /= steps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PowerUPLight()
    {
        spot.SetActive(true);

        StartCoroutine("ChangeLight");
    }

    IEnumerator ChangeLight()
    {
        Vector3 hsv = new Vector3(209f / 360, 0, 1);
        for(int i =0; i<steps;i++)
        {
            daylight.transform.Rotate(day_change);
            nightlight.transform.Rotate(night_change);

            daylight.GetComponent<Light>().intensity -= (4 / steps);
            hsv.y += 1 / steps;
            daylight.GetComponent<Light>().color = Color.HSVToRGB(hsv.x, hsv.y, hsv.z);

            yield return new WaitForSecondsRealtime(0.1f);
        }


    }
}
