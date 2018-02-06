using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

   public GameObject targetToLookAt;
    public GameObject targetMettle;

    private void Start() {
        targetMettle = GameObject.FindWithTag("MettleClone");
    }

    void Update () {

        if (targetMettle != null) {

            targetToLookAt = targetMettle;

        } 

    }
}
