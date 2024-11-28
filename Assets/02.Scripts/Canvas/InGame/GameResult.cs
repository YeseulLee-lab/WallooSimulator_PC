using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : Popup
{
    [Header("--------GameResult--------")]
    [SerializeField]
    private Text _clearTime;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private GameObject _gameSuccess;

    public void ShowOverResult()
    {
        ShowPopup();
        _gameOver.SetActive(true);
    }

    public void ShowSuccessResult()
    {
        ShowPopup();

        int _minute = (int)WallooManager.instance.clearTime / 60 % 60;
        int _second = (int)WallooManager.instance.clearTime;

        _clearTime.text = _minute.ToString("00") + ":" + _second.ToString("00");

        _gameSuccess.SetActive(true);
    }
}
