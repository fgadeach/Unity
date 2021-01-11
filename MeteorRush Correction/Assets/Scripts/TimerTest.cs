using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    Timer timer;
    float starTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

        starTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            starTime = Time.time;
            timer.Run();
        }
        
    }
}
