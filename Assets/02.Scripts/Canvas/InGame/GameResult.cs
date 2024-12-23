using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : Popup
{
    [SerializeField]
    private Button _backToMainBtn;

    [Header("--------GameResult--------")]
    [SerializeField]
    private Text _clearTime;
    [SerializeField]
    private Text _result;
    [SerializeField]
    private Image _resultImage;
    [SerializeField]
    private Sprite _failSp;
    [SerializeField]
    private Sprite _successSp;
    [SerializeField]
    private GameObject _failParticle;
    [SerializeField]
    private GameObject _successParticle;

    protected override void Start()
    {
        base.Start();
        _backToMainBtn.onClick.AddListener(() =>
        {
            PopupManager.Instance.twoButtonPopup.ShowPopup("메인 화면으로 돌아가시겠습니까?",
            () =>
            {
                SceneSwitcher.Instance.SwitchScene(Define.SceneName.Login);
            },
            () =>
            {

            });
            AudioManager.instance.PlaySound("ButtonClick");
        });
    }

    public void ShowFailResult()
    {
        AudioManager.instance.PlaySound("Fail");

        ShowPopup();
        _result.text = "칼퇴 실패...";
        _resultImage.sprite = _failSp;
        _clearTime.gameObject.SetActive(false);

        _failParticle.gameObject.SetActive(true);
    }

    public void ShowSuccessResult()
    {
        AudioManager.instance.PlaySound("Success");

        ShowPopup();
        _result.text = "칼퇴 성공!!!";
        _resultImage.sprite = _successSp;

        _successParticle.gameObject.SetActive(true);

        int _minute = (int)WallooManager.instance.clearTime / 60 % 60;
        int _second = (int)WallooManager.instance.clearTime;

        _clearTime.text = "클리어 타임: " + _minute.ToString("00") + ":" + _second.ToString("00");
    }
}
