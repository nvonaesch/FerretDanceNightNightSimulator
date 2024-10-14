using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lampeHautBas : MonoBehaviour
{
    public float vitesseRotation;
    private Light lampe; 
    private float angleInitial;

    public float angleAjouter;

    void Start()
    {
        lampe = GetComponent<Light>();
        angleInitial = transform.localEulerAngles.x; 
    }

    void Update()
    {
        float newAngle = Mathf.PingPong(Time.time * vitesseRotation, angleAjouter) + angleInitial;

        transform.localEulerAngles = new Vector3(newAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}