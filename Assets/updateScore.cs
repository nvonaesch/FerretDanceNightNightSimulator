using System;
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
        try{
            scoreTexte.text = score.ToString();
        }catch (NullReferenceException){}
    }

    // Update is called once per frame
    void Update()
    {
        try{
            scoreTexte.text = score.ToString() + " / 3 Furets heureux";
        }catch (NullReferenceException){

         }
        // if(scoreTexte!=null){
        //     scoreTexte.text = score.ToString() + " / 3 Furrets heureux";
        // }
        
    }

    public void incScore(int nombre) {
        score = score + nombre;
    }


}
