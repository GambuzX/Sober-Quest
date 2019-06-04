using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private int time;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        time = 0;
        InvokeRepeating("incrementTime", 1, 1);
    }

    public int getTime()
    {
        return time;
    }

    public void resetTime()
    {
        this.time = 0;
    }

    public void incrementTime()
    {
        this.time += 1;
    }
}
