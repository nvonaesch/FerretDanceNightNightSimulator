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
    private bool hasToGoToItsPlace = false ; // Variable pour savoir si l'objet doit aller à sa place sur la scène
    Vector3 objectSize ; //taille de l'objet (apparence et non collider)
    private float moveSpeed = 2.0f; //vitesse de déplacement
    private Vector3 targetPosition; // Position cible pour la translation
    private Boolean arrived = false;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        objectSize = GetComponent<Renderer>().bounds.size; //on récupère sa taille

        // Récupérer la caméra principale
        cameraTransform = Camera.main.transform;

        interactable.onSelectEntered.AddListener(OnGrab);
        // interactable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor) //quand on attrape l'objet
    {
        PositionBehindCamera(); // Positionner l'objet derrière la caméra
        isHeld = true; // Indiquer que l'objet est saisi
    }


    private void Update()
    {
        // Si l'objet est saisi, alors :
        if (isHeld)
        {
            PositionBehindCamera();
        }
        // Une fois que le joueur l'a emmené sur place :
        if (hasToGoToItsPlace)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            if (Vector3.Angle(transform.up, Vector3.up) > 45f){ //Pour empêcher la mascotte de tomber sur le côté
                transform.rotation = Quaternion.identity; }
            

            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                transform.position = targetPosition;
                hasToGoToItsPlace =false;
                arrived = true;
            }
        }
        // Quand le furet arrive à sa place
        if ((Vector3.Distance(transform.position, targetPosition) > 1f) && arrived == true)
        {
            transform.rotation = Quaternion.identity;
            hasToGoToItsPlace = true;
        }
    }

    private void PositionBehindCamera()
    {
        Vector3 positionBehindCamera = cameraTransform.position - cameraTransform.forward * 2.0f; // se positionner à cette distance de la caméra

        // Placer l'objet à la nouvelle position
        transform.position = positionBehindCamera;


    }

    private void OnTriggerEnter(Collider other)
    {
        //Si le tag "scene" entre dans la zone et si l'objet est saisi, alors
        if ((other.CompareTag("scene")) && isHeld)
        {
            string myTag = gameObject.tag; //on récupère le tag de l'objet
            isHeld = false; //l'objet est désaisi

            switch (myTag)
            {
                case "furetA":
                    targetPosition = new Vector3(100, 6.5f, 75);
                    break;
                case "furetB":
                    targetPosition = new Vector3(105, 6.5f, 72);
                    break;
                case "furetC":
                    targetPosition = new Vector3(95, 6.5f, 73);
                    break;
            }
            if (interactable != null)
            {
                interactable.enabled = false; // Désactiver le composant
                Debug.Log("XRGrabInteractable désactivé.");
            }
            hasToGoToItsPlace = true;
        }

    }
}