using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private Button _settingBtn;

    private void Start()
    {
        _settingBtn.onClick.AddListener(() =>
        {
            UIManager.instance.Setting.SetActive(true);
        });
    }
}
