using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInteractable : CustomInteractableBase
{
    public override void PlayWallooAction()
    {
        base.PlayWallooAction();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (WallooManager.instance.isWorkStart)
        {
            PlayWallooAction();
        }
        else
        {
            PopupManager.Instance.MouseToast.ShowToast("모니터를 켜야 근무를 시작합니다!");
        }
    }
}
