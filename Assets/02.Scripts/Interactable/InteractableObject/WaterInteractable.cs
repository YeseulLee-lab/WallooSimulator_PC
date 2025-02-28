using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteractable : CustomInteractableBase
{
    [SerializeField]
    private GameObject _waterParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WaterPoint>() != null)
        {
            other.GetComponent<WaterPoint>()._plantAnimator.SetBool("isWallooing", true);
            WaterToPlant(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WaterPoint>() != null)
        {
            other.GetComponent<WaterPoint>()._plantAnimator.SetBool("isWallooing", false);
            WaterToPlant(false);
        }
    }

    public void WaterToPlant(bool _active)
    {
        _waterParticle.SetActive(_active);
    }
}
