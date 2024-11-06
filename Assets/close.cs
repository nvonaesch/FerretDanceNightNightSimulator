using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int n;
    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");


        GameObject[] objetsAvecTag = GameObject.FindGameObjectsWithTag("bouton"); //récupérer ici les objets avec le tag boutton

        foreach (GameObject obj in objetsAvecTag)
        {
            obj.SetActive(false);
        }

    }
}
