using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

   [HideInInspector] public GameObject targetToLookAt;

	void Update () {

        if (GameObject.Find("MettleNPC(Clone)") != null) {

            var targetMettle = GameObject.Find("MettleNPC(Clone)");
            
            targetToLookAt = targetMettle;

        }

    }
}
