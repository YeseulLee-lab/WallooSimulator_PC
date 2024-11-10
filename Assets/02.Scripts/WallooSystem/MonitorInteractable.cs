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

        Debug.Log("����� ����");

        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        //����͸� �Ѿ� �� ������
        WallooManager.instance.isWorkStart = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            //��Ÿ���� �� á���� ���� �ൿ ����
            if (_curCoolTime <= 0f)
            {
                Debug.Log("���� �ൿ����");
                _isWallooing = true;
                WallooManager.instance.doubtRate += _interactableData.doubtRate;
                WallooManager.instance.wallooScore += _interactableData.wallooScore;
                if (_animator != null)
                    _animator.enabled = true;

                UniCoolTime().Forget();
            }
            else
            {
                Debug.Log("���� ��Ÿ���� ��á���ϴ�.");
            }

            black.DOFade(0f, 0.8f).OnComplete(() =>
            {
                black.gameObject.SetActive(false);
            });

            //����͸� �Ѿ� �� ������
            WallooManager.instance.isWorkStart = true;
        }
    }
}
