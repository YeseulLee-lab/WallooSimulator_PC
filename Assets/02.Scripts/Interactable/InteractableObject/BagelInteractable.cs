using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelInteractable : CustomInteractableBase
{
    [SerializeField]
    private GameObject _ateBagel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHead")
        {
            GetComponent<MeshRenderer>().enabled = false;
            _ateBagel.SetActive(true);
        }
    }
}
