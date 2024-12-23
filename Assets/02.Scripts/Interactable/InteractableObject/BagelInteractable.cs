using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagelInteractable : CustomInteractableBase
{
    [SerializeField]
    private GameObject _ateBagel;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        GetComponent<MeshRenderer>().enabled = false;
        _ateBagel.SetActive(true);

        WallooManager.instance.isWallooing = false;
        //일정시간 후에 베이글 복원
    }

    protected override void ResetObject()
    {
        GetComponent<MeshRenderer>().enabled = true;
        _ateBagel.SetActive(false);
    }
}
