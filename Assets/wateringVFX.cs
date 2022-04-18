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

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("I hit shit! " + other.name);

        if (other.TryGetComponent(out potScript pot))
        {
            Debug.Log("Hitting pot");
            pot.takeWater();
        }
    }
}
