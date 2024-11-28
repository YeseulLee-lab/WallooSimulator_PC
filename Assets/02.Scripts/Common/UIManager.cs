using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private SettingPopup _setting;
    public SettingPopup Setting => _setting;
    [SerializeField]
    private GameResult _gameResult;
    public GameResult GameResult => _gameResult;

    private void Awake()
    {
        instance = this;
    }
}
