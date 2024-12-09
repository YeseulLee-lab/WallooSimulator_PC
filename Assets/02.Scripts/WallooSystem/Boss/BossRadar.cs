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
            if (WallooManager.instance.isWallooing)
            {
                if (_height <= 2f)
                {
                    Debug.Log("게임오버");
                }
                else
                {
                    Debug.Log("경고");
                }
            }
        }
    }
}
