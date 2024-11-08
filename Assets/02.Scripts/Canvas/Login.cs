using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn;

    private void Start()
    {
        _startBtn.onClick.AddListener(() =>
        {
            SceneSwitcher.Instance.SwitchScene(Define.SceneName.Office);
        });
    }
}
