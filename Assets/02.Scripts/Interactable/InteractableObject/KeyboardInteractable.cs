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
            PopupManager.Instance.MouseToast.ShowToast("You need to turn on the monitor to start working!");
        }
    }
}
