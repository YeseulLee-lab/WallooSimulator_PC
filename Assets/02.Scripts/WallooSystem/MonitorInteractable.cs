using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            //쿨타임이 다 찼으면 월루 행동 가능
            if (_curCoolTime <= 0f)
            {
                Debug.Log("월루 행동시작");
                _isWallooing = true;
                WallooManager.instance.doubtRate += _interactableData.doubtRate;
                WallooManager.instance.wallooScore += _interactableData.wallooScore;
                if (_animator != null)
                    _animator.enabled = true;

                UniCoolTime().Forget();
            }
            else
            {
                Debug.Log("아직 쿨타임이 안찼습니다.");
            }

            black.DOFade(0f, 0.8f).OnComplete(() =>
            {
                black.gameObject.SetActive(false);
            });

            //모니터를 켜야 일 시작함
            WallooManager.instance.isWorkStart = true;
        }
    }
}
