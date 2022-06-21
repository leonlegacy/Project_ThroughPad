using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowCtrl : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Animator sky;
    bool isOpen = false;
    bool isDawn = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isOpen = !isOpen;
            anim.SetBool("open", isOpen);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isDawn = !isDawn;
            sky.SetBool("dawn", isDawn);
        }
    }
}
