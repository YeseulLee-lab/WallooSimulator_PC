using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractable : CustomInteractableBase
{
    public override void PlayWallooAction()
    {
        base.PlayWallooAction();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        }
    }
}
