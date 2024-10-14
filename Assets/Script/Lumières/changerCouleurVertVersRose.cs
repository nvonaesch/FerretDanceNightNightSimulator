using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changerCouleurVertVersRose : MonoBehaviour
{
    float duration = 1.0f;
    Light light;
    Color couleur1 = Color.green;
    Color couleur2 = new Color(1f, 0.75f, 0.79f);

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
