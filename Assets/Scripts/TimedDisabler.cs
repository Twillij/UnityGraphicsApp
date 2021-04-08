using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisabler : MonoBehaviour
{
    public bool isTicking = true;
    public float timer = 10;
    
    private float clock = 0;

    void Update()
    {
        if (isTicking)
        {
            clock += Time.deltaTime;

            if (clock > timer)
            {
                isTicking = false;
                gameObject.SetActive(false);
            }
        }
    }
}
