using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUIText : MonoBehaviour
{

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        int seconds = GameObject.FindObjectOfType<TimeCounter>().getTime();

        int minutes = seconds / 60;
        seconds = seconds % 60;

        string button_text = "";
        if (minutes < 10) button_text += "0";
        button_text += minutes + " : ";
        if (seconds < 10) button_text += "0";
        button_text += seconds;

        text.text = button_text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
