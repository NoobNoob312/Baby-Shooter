using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBaby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % 1 <= 1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 20f);
        }
        if (Time.time % 1 <= 0.75f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Time.time % 1 <= 0.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -20f);
        }
        if (Time.time % 1 <= 0.25f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
