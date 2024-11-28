using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("--------Audio--------")]
    [SerializeField]
    private Sprite[] _audioSpArr;
    [SerializeField]
    private Button _audioBtn;
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
        });

        _rulesBtn.onClick.AddListener(() =>
        {
            _rulesPopup.ShowPopup();
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
            
        });

        _audioBtn.onClick.AddListener(SetAudioSp);

        AudioManager.instance.PlayMusic(_bgmClip);

        if (AudioManager.instance.masterVolumePercent > 0f)
        {
            _audioBtn.GetComponent<Image>().sprite = _audioSpArr[1];
        }
        else
        {
            _audioBtn.GetComponent<Image>().sprite = _audioSpArr[0];
        }
    }

    private void SetAudioSp()
    {
        if (AudioManager.instance.masterVolumePercent > 0f)
        {
            AudioManager.instance.SetVolume(0f, AudioManager.AudioChannel.Master);
            _audioBtn.GetComponent<Image>().sprite = _audioSpArr[0];
        }
        else
        {
            AudioManager.instance.SetVolume(1f, AudioManager.AudioChannel.Master);
            _audioBtn.GetComponent<Image>().sprite = _audioSpArr[1];
        }
    }
}
