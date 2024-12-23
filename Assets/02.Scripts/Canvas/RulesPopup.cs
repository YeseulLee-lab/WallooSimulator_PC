using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesPopup : Popup
{
    [SerializeField]
    private GameObject[] _rulesArr;
    [SerializeField]
    private Button _nextBtn;
    [SerializeField]
    private Button _prevBtn;

    private int _curIdx = 0;

    protected override void Start()
    {
        base.Start();
        _nextBtn?.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("ButtonClick");
            _rulesArr[_curIdx].SetActive(false);
            _curIdx++;
            _rulesArr[_curIdx].SetActive(true);
            _prevBtn?.gameObject.SetActive(true);
            if (_curIdx >= _rulesArr.Length - 1)
            {
                _nextBtn.gameObject.SetActive(false);
                _curIdx = _rulesArr.Length - 1;
                return;
            }
        });

        _prevBtn?.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("ButtonClick");
            _rulesArr[_curIdx].SetActive(false);
            _curIdx--;
            _rulesArr[_curIdx].SetActive(true);
            _nextBtn?.gameObject.SetActive(true);
            if (_curIdx <= 0)
            {
                _prevBtn.gameObject.SetActive(false);
                _curIdx = 0;
                return;
            }
        });
    }

    public override void HidePopup()
    {
        _content.DOScale(0f, 0.5f).SetEase(Ease.InOutExpo).OnComplete(() =>
        {
            gameObject.SetActive(false);

            _rulesArr[_curIdx].SetActive(false);
            _curIdx = 0;
            _nextBtn.gameObject.SetActive(true);
            _prevBtn.gameObject.SetActive(false);
            _rulesArr[_curIdx].SetActive(true);
        });
    }
}
