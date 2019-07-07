using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Point : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int number;

    public float increase_speed = 100;
    public int roll_speed = 8;

    int current_number = 0;
    int index;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index%roll_speed == 0)
        {
            if(current_number<number)
            {
                if ((number - current_number) < 100)
                    current_number = number;
                else
                    //text.richText = true;
                    current_number += (int)((number - current_number) / increase_speed);
            }
            else if (current_number > number)
            {
                current_number = number;
            }
            text.text = current_number.ToString();

        }
        index++;

    }

    public static void AddPoint(int num)
    {
        Point.number += num;
    }

    public void SetPoint(int num)
    {
        number = num;
    }
}
