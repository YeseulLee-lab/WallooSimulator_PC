using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseToast : MonoBehaviour
{
    [SerializeField]
    private Text _message;

    private void Start()
    {
        _message.color = new Color(1f, 1f, 1f, 0f);
    }

    public void ShowToast(string message, Vector2 mousePos)
    {
        _message.rectTransform.position = mousePos;
        gameObject.SetActive(true);
        _message.DOFade(1f, 0.2f).OnComplete(() =>
        {
            _message.DOFade(0f, 0.2f);
        });
        _message.text = message;
    }
}
