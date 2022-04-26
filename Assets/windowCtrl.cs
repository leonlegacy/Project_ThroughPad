using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowCtrl : MonoBehaviour
{
    [SerializeField] Animator anim;
    bool isOpen = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isOpen = !isOpen;
            anim.SetBool("open", isOpen);
        }
    }
}
