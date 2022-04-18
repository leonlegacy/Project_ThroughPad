using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ixableScript : MonoBehaviour
{
    [SerializeField] IXRaycaster ixRay;
    [SerializeField] UnityEvent hitEvent;
    public ParticleSystem particle;
    enum objects { watering, pot};
    [SerializeField] objects thisObject;


    public bool followRay = false;

    private void Update()
    {
        if (followRay) 
        {
            transform.position = ixRay.getRayhitPosition();
            transform.rotation = ixRay.getTrackerRotation();
        } 
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
