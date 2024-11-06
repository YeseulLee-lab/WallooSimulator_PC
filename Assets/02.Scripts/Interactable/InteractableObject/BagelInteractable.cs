using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelInteractable : CustomGrabInteractableBase
{
    [SerializeField]
    private GameObject _ateBagel;
    [SerializeField]
    private AudioClip _eatingAC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHead")
        {
            AudioManager.instance.PlaySound(_eatingAC);
            GetComponent<MeshRenderer>().enabled = false;
            _ateBagel.SetActive(true);
        }
    }
}
