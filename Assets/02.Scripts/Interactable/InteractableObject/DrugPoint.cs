using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _pillObject;
    [SerializeField]
    private AudioClip _pillAudioClip;

    public void EnablePillObject()
    {
        _pillObject.SetActive(true);
        AudioManager.instance.PlaySound(_pillAudioClip);
        this.enabled =false;
    }
}
