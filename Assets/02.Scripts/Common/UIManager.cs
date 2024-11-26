using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private SettingPopup _setting;

    public SettingPopup Setting => _setting;

    private void Awake()
    {
        instance = this;
    }
}
