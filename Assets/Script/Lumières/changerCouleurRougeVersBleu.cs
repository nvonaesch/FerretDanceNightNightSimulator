using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changerCouleur : MonoBehaviour
{
    float duration = 1.0f;
    Light light;
    Color couleur1 = Color.red;
    Color couleur2 = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        light.color = Color.Lerp(couleur1, couleur2, t);
    }
}
