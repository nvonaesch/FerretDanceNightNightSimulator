using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changerEntreCouleurs : MonoBehaviour
{
    float duration = 1.0f;
    Light light;
    public Color couleur1;
    public Color couleur2;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        light.color = Color.Lerp(couleur1, couleur2, t);
    }
}
