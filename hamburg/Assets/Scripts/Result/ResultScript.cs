using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ResultScript : MonoBehaviour
{
    int playTime { get; set; } = 0;
    int stage { get; set; } = 0;

    void Awake()
    {
        CalcPlayTimeAndSetNumber();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void CalcPlayTimeAndSetNumber()
    {
        stage = InGameScript.Stage;

        var time = TimeSpan.FromMilliseconds(InGameScript.PlayTime * 1000);

        playTime = (time.Milliseconds / 10) + time.Seconds * 100 + time.Minutes * 10000;
    }
}
