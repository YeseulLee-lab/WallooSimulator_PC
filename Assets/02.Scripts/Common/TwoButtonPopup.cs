using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TwoButtonPopup : Popup
{
    [SerializeField]
    private Text _title;
    [SerializeField]
    private Button _noBtn;
    [SerializeField]
    private Button _yesBtn;

    public void ShowPopup(string title, UnityAction yesAction = null, UnityAction noAction = null)
    {
        gameObject.SetActive(true);

        _title.text = title;
        _yesBtn?.onClick.AddListener(() =>
        {
            HidePopup();
            yesAction?.Invoke();
        });

        _noBtn?.onClick.AddListener(() =>
        {
            HidePopup();
            noAction?.Invoke();
        });
    }
}
