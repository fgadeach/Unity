﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields
    //timer duration
    float totalSeconds = 0;

    //timer execution
    float elapsedSeconds = 0;
    bool running = false;
    bool started = false;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }
    #region Properties
    public float Duration
    {
        set
        {
            if(!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get { return started && !running; }
    }

    public bool Running
    {
        get { return running; }
    }
    #endregion

    #region Methods
    // Update is called once per frame
    void Update()
    {
        if (running) {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds) {
                running = false;
            }
        }
        
    }

    public void Run() {
        if (totalSeconds > 0) {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }
    #endregion
}
