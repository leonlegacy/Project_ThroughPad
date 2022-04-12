using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IXRaycaster : MonoBehaviour
{
    [SerializeField] Transform ipad;
    [SerializeField] LayerMask ignoreLayer;
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
            Debug.Log("Hit " + hit.transform.name);
        }
    }
}
