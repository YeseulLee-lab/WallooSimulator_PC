using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField]
    private GameObject _mLiquid;
    [SerializeField]
    private GameObject _mLiquidMesh;

    private int _mSloshSpeed = 60;
    private int _mRotateSpeed = 15;

    private int differece = 25;

    private void Update()
    {
        Slosh();

        _mLiquidMesh.transform.Rotate(Vector3.up * _mRotateSpeed * Time.deltaTime, Space.Self);
    }

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 finalRotaion = Quaternion.RotateTowards(_mLiquid.transform.localRotation, inverseRotation, _mSloshSpeed * Time.deltaTime).eulerAngles;

        finalRotaion.x = ClampRotationValue(finalRotaion.x, differece);
        finalRotaion.z = ClampRotationValue(finalRotaion.z, differece);

        _mLiquid.transform.localEulerAngles = finalRotaion;
    }

    private void MoreSlosh()
    {
        
    }

    private float ClampRotationValue(float value, float differece)
    {
        float returnValue = 0.0f;

        if (value > 180)
        {
            returnValue = Mathf.Clamp(value, 360 - differece, 360);
        }
        else
        {
            returnValue = Mathf.Clamp(value, 0, differece);
        }

        return returnValue;
    }
}
