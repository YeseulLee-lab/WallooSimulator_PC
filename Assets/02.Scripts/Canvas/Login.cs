using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("--------Audio--------")]
    [SerializeField]
    private Button _audioBtn;
    [SerializeField]
    private Image _volImg;
    [SerializeField]
    private AudioClip _bgmClip;

    [Header("--------UI--------")]
    [SerializeField]
    private Button _startBtn;
    [SerializeField]
    private Button _rulesBtn;
    [SerializeField]
    private Button _exitBtn;
    [SerializeField]
    private RulesPopup _rulesPopup;

    private void Start()
    {
        _startBtn.onClick.AddListener(() =>
        {
            SceneSwitcher.Instance.SwitchScene(Define.SceneName.Office_1);
            AudioManager.instance.PlaySound("ButtonClick");
        });

        _rulesBtn.onClick.AddListener(() =>
        {
            _rulesPopup.ShowPopup();
            AudioManager.instance.PlaySound("ButtonClick");
        });

        _exitBtn.onClick.AddListener(() =>
        {
            PopupManager.Instance.twoButtonPopup.ShowPopup("게임을 종료하시겠습니까?", 
                () =>
                {
                    Application.Quit();
                },
                () =>
                {
                    
                });
            AudioManager.instance.PlaySound("ButtonClick");
        });

        /*if (AudioManager.instance.masterVolumePercent > 0f)
        {
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Master);
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Sfx);
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Bgm);

            _volImg.gameObject.SetActive(true);
        }*/

        //_audioBtn.onClick.AddListener(SetAudioSp);

        AudioManager.instance.PlayMusic(_bgmClip);
        AudioManager.instance.StopAmbientSound();
    }

    private void SetAudioSp()
    {
        if (AudioManager.instance.masterVolumePercent > 0f)
        {
            AudioManager.instance.SetVolume(0f, AudioManager.AudioChannel.Master);
            _volImg.gameObject.SetActive(false);
        }
        else
        {
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Master);
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Sfx);
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Bgm);
            _volImg.gameObject.SetActive(true);
        }
    }
}
