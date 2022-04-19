using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipadBinding : MonoBehaviour
{
    [SerializeField] Transform ipad;

    private void Start()
    {
        StartCoroutine(bind());
    }

    IEnumerator bind()
    {
        yield return new WaitForSeconds(1);
        ipad.parent = transform.GetChild(0);
        ipad.localPosition = Vector3.zero;
        ipad.localRotation = Quaternion.identity;
    }
}
