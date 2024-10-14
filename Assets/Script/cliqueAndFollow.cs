using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class cliqueAndFollow : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private Transform cameraTransform;
    private bool isHeld = false; // Variable pour savoir si l'objet est saisi
    private bool hasToGoToItsPlace = false ; // Variable pour savoir si l'objet doit aller � sa place sur la sc�ne
    Vector3 objectSize ; //taille de l'objet (apparence et non collider)
    private float moveSpeed = 2.0f; //vitesse de d�placement
    private Vector3 targetPosition; // Position cible pour la translation
    private Boolean arrived = false;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        objectSize = GetComponent<Renderer>().bounds.size; //on r�cup�re sa taille

        // R�cup�rer la cam�ra principale
        cameraTransform = Camera.main.transform;

        interactable.onSelectEntered.AddListener(OnGrab);
        // interactable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        PositionBehindCamera(); // Positionner l'objet derri�re la cam�ra
        isHeld = true; // Indiquer que l'objet est saisi
    }


    private void Update()
    {
        // Si l'objet est saisi, alors :
        if (isHeld)
        {
            PositionBehindCamera();
        }
        if (hasToGoToItsPlace)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                transform.position = targetPosition;
                hasToGoToItsPlace =false;
                arrived = true;
            }
        }
        if ((Vector3.Distance(transform.position, targetPosition) > 0.5f) && arrived == true)
        {
            hasToGoToItsPlace = true;
        }
    }

    private void PositionBehindCamera()
    {
        // Positionner l'objet derri�re la cam�ra
        /*Vector3 positionBehindCamera = cameraTransform.position - cameraTransform.forward * 1.0f; // Ajustez la distance si n�cessaire
        transform.position = positionBehindCamera;*/
        // Positionner l'objet derri�re la cam�ra
        Vector3 positionBehindCamera = cameraTransform.position - cameraTransform.forward * 1.0f; // Ajustez la distance si n�cessaire

        // Calculer la position au sol
        positionBehindCamera.y = cameraTransform.position.y - objectSize.y ; // Mettre l'objet au niveau du sol

        // Placer l'objet � la nouvelle position
        transform.position = positionBehindCamera;


    }

    private void OnTriggerEnter(Collider other)
    {
        //Si le tag "scene" entre dans la zone et si l'objet est saisi, alors
        if ((other.CompareTag("scene")) && isHeld)
        {
            string myTag = gameObject.tag; //on r�cup�re le tag de l'objet
            isHeld = false; //l'objet est d�saisi
            Debug.Log("Object is released because of trigger.");

            switch (myTag)
            {
                case "furetA":
                    targetPosition = new Vector3(100, 6, 75);
                    break;
                case "furetB":
                    targetPosition = new Vector3(105, 6, 72);
                    break;
                case "furetC":
                    targetPosition = new Vector3(95, 6, 73);
                    break;
            }

            if (interactable != null)
            {
                interactable.enabled = false; // D�sactiver le composant
                Debug.Log("XRGrabInteractable d�sactiv�.");
            }

            //targetPosition = new Vector3(100, 6 , 75);

            hasToGoToItsPlace = true;
        }
        Debug.Log("Trigger Entered by: " + other.name); // Debug: Voir quel objet entre
                                                        // V�rifiez si le collider entrant est celui que vous souhaitez

    }
}

