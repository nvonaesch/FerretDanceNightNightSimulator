using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ChangeColor();
        }
    }

    // Update is called once per frame
    void ChangeColor()
    {
        float newSize = Random.Range(0.5f, 3.0f); // Valeurs entre 0.5 et 3.0 par exemple
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }
}
