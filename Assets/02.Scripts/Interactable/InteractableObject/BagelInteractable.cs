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
    }
}
