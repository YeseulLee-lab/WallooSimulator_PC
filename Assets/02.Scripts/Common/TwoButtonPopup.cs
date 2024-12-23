using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TwoButtonPopup : Popup
{
    [Header("--------Content--------")]
    [SerializeField]
    private Text _title;
    [SerializeField]
    private Button _noBtn;
    [SerializeField]
    private Button _yesBtn;

    public void ShowPopup(string title, UnityAction yesAction = null, UnityAction noAction = null)
    {
        _yesBtn.onClick.RemoveAllListeners();
        _noBtn.onClick.RemoveAllListeners();

        gameObject.SetActive(true);
        _content.DOScale(1f, 0.5f).SetEase(Ease.InOutExpo);

        _title.text = title;
        _yesBtn?.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _content.transform.localScale = Vector3.zero;
            yesAction?.Invoke();

            AudioManager.instance.PlaySound("ButtonClick");
        });

        _noBtn?.onClick.AddListener(() =>
        {
            HidePopup();
            noAction?.Invoke();

            AudioManager.instance.PlaySound("ButtonClick");
        });
    }
}
