using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateScore : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI scoreTexte;
    // Start is called before the first frame update
    void Start()
    {
        scoreTexte.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreTexte.text = score.ToString();
    }

    public void incScore(int nombre) {
        score = score + nombre;
    }


}
