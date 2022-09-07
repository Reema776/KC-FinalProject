using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TemerText;
    public float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time - StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - StartTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        TemerText.text = minutes + ":" + seconds;   
    }
}
