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
}
