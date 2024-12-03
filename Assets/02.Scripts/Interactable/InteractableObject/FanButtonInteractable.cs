using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FanButtonInteractable : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private int _blendShapeIdx;
    [SerializeField]
    private SkinnedMeshRenderer _fanSM;
    [SerializeField]
    private Animator _animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_animator.GetBool("isWallooing"))
        {
            _fanSM.SetBlendShapeWeight(_blendShapeIdx, 1);
            _animator?.SetBool("isWallooing", true);
        }
        else
        {
            _fanSM.SetBlendShapeWeight(_blendShapeIdx, 0);
            _animator?.SetBool("isWallooing", false);
        }
    }
}
