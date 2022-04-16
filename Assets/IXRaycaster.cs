using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IXRaycaster : MonoBehaviour
{
    [SerializeField] Transform ipad;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] LayerMask positionLayer;
    Vector3 hitPosition;
    private void Update()
    {
        transform.LookAt(ipad);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, ~ignoreLayer))
        {        
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 3);
            if (hit.transform.GetComponent<ixableScript>())
            {
                hit.transform.GetComponent<ixableScript>().eventTrigger();
                if (hit.transform.GetComponent<Collider>()) hit.transform.GetComponent<Collider>().enabled = false;
            }
            //Debug.Log("Hit " + hit.transform.name);
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, positionLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 0.5f);
            hitPosition = hit.point;
            
        }
        
    }

    public Quaternion getTrackerRotation()
    {
        return ipad.rotation;
    }

    public Vector3 getRayhitPosition()
    {
        return hitPosition;
    }



}
