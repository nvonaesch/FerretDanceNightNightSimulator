using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVR : MonoBehaviour
{
    public Transform leftHandBone;    // Le Transform du bone de la main gauche
    public Transform rightHandBone;   // Le Transform du bone de la main droite

    public Transform leftHandTarget;  // Référence au contrôleur gauche
    public Transform rightHandTarget; // Référence au contrôleur droit

    void Update()
    {
        // Déplacer le bone de la main gauche pour suivre le contrôleur gauche
        if (leftHandBone && leftHandTarget)
        {
            leftHandBone.position = leftHandTarget.position;
            leftHandBone.rotation = leftHandTarget.rotation;
        }

        // Déplacer le bone de la main droite pour suivre le contrôleur droit
        if (rightHandBone && rightHandTarget)
        {
            rightHandBone.position = rightHandTarget.position;
            rightHandBone.rotation = rightHandTarget.rotation;
        }
    }
}
