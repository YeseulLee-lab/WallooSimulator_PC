using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField]
    protected Button _closeBtn;
    [SerializeField]
    protected Button _background;
    [SerializeField]
    protected RectTransform _content;

    protected virtual void Start()
    {
        _content.localScale = Vector3.zero;

        _closeBtn?.onClick.AddListener(() =>
        {
            HidePopup();

            AudioManager.instance.PlaySound("ButtonClick");
        });
        _background?.onClick.AddListener(() =>
        {
            HidePopup();
        });
    }

    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
        _content.DOScale(1f, 0.5f).SetEase(Ease.InOutExpo);
    }

    public virtual void HidePopup()
    {
        _content.DOScale(0f, 0.5f).SetEase(Ease.InOutExpo).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
