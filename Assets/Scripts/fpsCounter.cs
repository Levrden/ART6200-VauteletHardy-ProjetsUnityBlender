using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class fpsCounter : MonoBehaviour
{
    float dTime = 0;
    float fps = 0;

    // Update is called once per frame
    void Update()
    {
        dTime = Time.deltaTime;
        fps = 1/dTime;
        if (fps < 90)
        {
            Debug.Log(fps);
        }
    }
}
