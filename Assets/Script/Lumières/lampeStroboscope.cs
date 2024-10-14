using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampeStroboscope : MonoBehaviour
{

    public float duration = 0.5f; 
    private Light lampe;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        lampe = GetComponent<Light>();
        timer = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            lampe.enabled = !lampe.enabled; 
            timer = 0f; 
        }
    }
}
