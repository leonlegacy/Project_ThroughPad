using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potScript : MonoBehaviour
{
    public int waterCount = 0;
    public int triggrAmount = 100;
    public bool isTriggered = false;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem FlowerParticle;
    public void takeWater()
    {
        Debug.Log("Taking water");
        if (!isTriggered)
        {
            waterCount += 1;
            if (waterCount > triggrAmount)
            {
                isTriggered = true;
                anim.SetTrigger("grow");
                FlowerParticle.Play();
            }
        }
        
    }
}
