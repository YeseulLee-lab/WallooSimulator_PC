using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseToast : MonoBehaviour
{
    [SerializeField]
    private Text _message;

    private bool isShowing = false;

    private void Start()
    {
        _message.color = new Color(_message.color.a, _message.color.b, _message.color.g, 0f);
    }

    public void ShowToast(string message)
    {
        if (isShowing)
        {
            return;
        }
        isShowing = true;
        gameObject.SetActive(true);
        _message.rectTransform.position = Input.mousePosition;
        _message.DOFade(1f, 0.2f).OnComplete(() =>
        {
            _message.rectTransform.DOMove(new Vector2(_message.rectTransform.position.x, _message.rectTransform.position.y + 20f), 0.5f);
            _message.DOFade(0f, 1f).OnComplete(() =>
            {
                isShowing = false;
            });
        });
        _message.text = message;
    }
}
