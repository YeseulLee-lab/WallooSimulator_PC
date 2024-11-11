using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MonitorInteractable : CustomInteractableBase
{
    [SerializeField]
    private Image black;

    #region Unity Life Cycle
    protected override void Start()
    {
        base.Start();
    }
    #endregion

    public override void PlayWallooAction()
    {
        base.PlayWallooAction();

        Debug.Log("모니터 켜짐");

        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        //모니터를 켜야 일 시작함
        WallooManager.instance.isWorkStart = true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        PlayWallooAction();
    }
}
