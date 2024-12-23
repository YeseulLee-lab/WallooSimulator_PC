using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : Popup
{
    [SerializeField]
    private Button _backToMainBtn;
    [SerializeField]
    private Toggle _musicOnToggle;
    [SerializeField]
    private Toggle _musicOffToggle;
    [SerializeField]
    private Toggle _soundOnToggle;
    [SerializeField]
    private Toggle _soundOffToggle;

    protected override void Start()
    {
        base.Start();
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
            AudioManager.instance.PlaySound("ButtonClick");
        });

        if (AudioManager.instance.masterVolumePercent > 0)
        {
            _musicOnToggle.isOn = true;
            _soundOnToggle.isOn = true;
        }
        else
        {
            _musicOnToggle.isOn = false;
            _soundOnToggle.isOn = false;
        }

        _musicOnToggle.isOn = AudioManager.instance.bgmVolumePercent > 0;
        _soundOnToggle.isOn = AudioManager.instance.sfxVolumePercent > 0;

        _musicOnToggle.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Bgm);
                AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Master);
            }
            else
            {
                AudioManager.instance.SetVolume(0f, AudioManager.AudioChannel.Bgm);
            }
        });

        _soundOnToggle.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Sfx);
                AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Master);
            }
            else
            {
                AudioManager.instance.SetVolume(0f, AudioManager.AudioChannel.Sfx);
            }
        });
    }
}
