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

    public virtual void ShowPopup()
    {

    }

    public virtual void HidePopup()
    {
        gameObject.SetActive(false);
    }
}
