using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugInteractable : CustomInteractableBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DrugPoint>() != null)
        {
            other.GetComponent<DrugPoint>().EnablePillObject();
        }
    }
}
