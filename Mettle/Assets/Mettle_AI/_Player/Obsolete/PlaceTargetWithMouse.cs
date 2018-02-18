using System;
using UnityEngine;


public class PlaceTargetWithMouse : MonoBehaviour
{
    public float surfaceOffset = 0.1f;
    private GameObject setTargetOn;


    // Update is called once per frame   Yeah! Yeah! We know...
    private void Update()
    {

        if (GameObject.Find("MettlePlayer(Clone)") != null) {

            setTargetOn = GameObject.Find("MettlePlayer(Clone)");

        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       
        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }
        
        transform.position = hit.point + hit.normal*surfaceOffset;
        
        if (setTargetOn != null)
        {
            setTargetOn.SendMessage("SetTarget", transform);
        }
    }
}


