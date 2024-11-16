using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _rotateValue = 15f;
    private Vector3 _originRotation;

    private bool _isRotating = false;

    public int _aRotateCnt = 1;
    public int _dRotateCnt = 1;
    public int _sRotateCnt = 1;
    public int _wRotateCnt = 1;    

    private void Start()
    {
        _originRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        if (!_isRotating)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_aRotateCnt >= 1)
                {
                    RotateCamera(0f, -_rotateValue, 0f);
                    _dRotateCnt ++;
                    _aRotateCnt --;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (_dRotateCnt >= 1)
                {
                    RotateCamera(0f, _rotateValue, 0f);
                    _aRotateCnt ++;
                    _dRotateCnt --;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (_wRotateCnt >= 1)
                {
                    RotateCamera(-10f, 0f, 0f);
                    _sRotateCnt ++;
                    _wRotateCnt --;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (_sRotateCnt >= 1)
                {
                    RotateCamera(10f, 0f, 0f);
                    _wRotateCnt ++;
                    _sRotateCnt --;
                }
            }
        }
    }

    private void RotateCamera(float x, float y, float z)
    {
        _isRotating = true;
        transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x + x, transform.localEulerAngles.y + y, transform.localEulerAngles.z + z), 0.5f)
            .OnComplete(() =>
            {
                _isRotating = false;
            });
    }
}
