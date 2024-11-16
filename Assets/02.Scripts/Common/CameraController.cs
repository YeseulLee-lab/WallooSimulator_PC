using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _rotateValue = 15f;
    private Vector3 _originRotation;

    private bool isRotating = false;

    private void Start()
    {
        _originRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                RotateCamera(0f, - _rotateValue, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                RotateCamera(0f, _rotateValue, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                RotateCamera(-10f, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                RotateCamera(10f, 0f, 0f);
            }
        }
    }

    private void RotateCamera(float x, float y, float z)
    {
        isRotating = true;
        transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x + x, transform.localEulerAngles.y + y, transform.localEulerAngles.z + z), 0.5f)
            .OnComplete(() =>
            {
                isRotating = false;
            });
    }
}
