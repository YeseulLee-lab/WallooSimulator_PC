using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRadar : MonoBehaviour
{
    private Pyramid _pyramid;
    private float _height;

    private void Start()
    {
        _pyramid = GetComponent<Pyramid>();
        _height = _pyramid.height;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_height <= 1.8f)
            {
                Debug.Log("���ӿ���");
            }
            else
            {
                Debug.Log("���");
            }
        }
    }
}
