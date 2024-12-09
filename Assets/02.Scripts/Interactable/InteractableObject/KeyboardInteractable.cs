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
            PopupManager.Instance.MouseToast.ShowToast("����͸� �Ѿ� �ٹ��� �����մϴ�!");
        }
    }
}
