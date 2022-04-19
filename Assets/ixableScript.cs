using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ixableScript : MonoBehaviour
{
    [SerializeField] IXRaycaster ixRay;
    [SerializeField] UnityEvent hitEvent;
    [SerializeField] Transform rotatable;
    //public ParticleSystem particle;
    enum objects { watering, pot};
    [SerializeField] objects thisObject;


    public bool followRay = false;

    private void Start()
    {
        rotatable = transform;
    }

    private void Update()
    {
        if (followRay) 
        {
            transform.position = ixRay.getRayhitPosition();
            rotatable.transform.rotation = ixRay.getTrackerRotation();
        } 
    }
    
    public void setIXRay(IXRaycaster ray)
    {
        ixRay = ray;
    }
    
    public void eventTrigger()
    {
        Debug.Log("EventTriggered");
        hitEvent.Invoke();
    }

    public void followRaycast()
    {
        followRay = true;
    }
}
