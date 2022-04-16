using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateringVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem watering;
    [SerializeField] bool isPour = false;
    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) <= 90)
        {
            watering.Play();
            isPour = true;
        }
        else
        {
            watering.Stop();
            isPour = false;
        }
    }
}
