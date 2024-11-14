using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotateValue = 15f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - rotateValue, transform.localEulerAngles.z), 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotateValue, transform.localEulerAngles.z), 0.5f);
        }
    }
}
