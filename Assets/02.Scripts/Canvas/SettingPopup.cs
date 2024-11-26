using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : Popup
{
    [SerializeField]
    private Button _backToMainBtn;

    private void Start()
    {
        _background.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        _closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        _backToMainBtn.onClick.AddListener(() =>
        {
            PopupManager.Instance.twoButtonPopup.ShowPopup("메인 화면으로 돌아가시겠습니까?", 
            () =>
            {
                HidePopup();
                SceneSwitcher.Instance.SwitchScene(Define.SceneName.Login);
            },
            () =>
            {

            });
        });
    }
}
