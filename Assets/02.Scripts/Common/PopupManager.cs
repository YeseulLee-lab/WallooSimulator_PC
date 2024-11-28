using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField]
    private TwoButtonPopup _twoButtonPopup;
    public TwoButtonPopup twoButtonPopup
    {
        get
        {
            return _twoButtonPopup;
        }
    }

    [SerializeField]
    private MouseToast _moustToast;
    public MouseToast MouseToast => _moustToast;
}
