using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private Button _background;
    [SerializeField]
    private Button _closeBtn;

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
    }
}
