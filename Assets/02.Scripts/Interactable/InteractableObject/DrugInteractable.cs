using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DrugPoint>() != null)
        {
            other.GetComponent<DrugPoint>().EnablePillObject();
        }
    }
}
