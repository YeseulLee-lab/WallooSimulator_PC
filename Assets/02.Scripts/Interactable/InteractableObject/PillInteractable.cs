using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillInteractable : CustomGrabInteractableBase
{
    [SerializeField]
    private AudioClip _eatingAC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHead")
        {
            AudioManager.instance.PlaySound(_eatingAC);
            gameObject.SetActive(false);
        }
    }
}
