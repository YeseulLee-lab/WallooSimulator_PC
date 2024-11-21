using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Button _background;
    [SerializeField]
    private Button _closeBtn;
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
            SceneSwitcher.Instance.SwitchScene(Define.SceneName.Login);
        });
    }
}
