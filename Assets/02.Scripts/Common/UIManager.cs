using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject _setting;

    public GameObject Setting => _setting;

    private void Awake()
    {
        instance = this;
    }
}
