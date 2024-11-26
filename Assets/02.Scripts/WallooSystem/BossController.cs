using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _points;

    [Header("--------Boss--------")]
    [SerializeField]
    private Transform _boss;
    [SerializeField]
    private SkinnedMeshRenderer _bossSM;
    [SerializeField]
    private Material _transparentMat;

    private Material _originalMat;

    private void Start()
    {
        _originalMat = _bossSM.material;

        MoveBoss(0);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }

    private void MoveBoss(int index)
    {
        _boss.DOMove(_points[index].position, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _bossSM.material = _transparentMat;
            _bossSM.material.DOFade(0f, 1f).OnComplete(() =>
            {
                _boss.localScale = new Vector3(_boss.localScale.x, _boss.localScale.y, _boss.localScale.z * -1);
                _bossSM.material.DOFade(1f, 1f).OnComplete(() =>
                {
                    _bossSM.material = _originalMat;

                    if (index < _points.Length - 1)
                    {
                        MoveBoss(index + 1);
                    }
                    else
                    {
                        MoveBoss(0);
                    }
                });
            });
        });
    }
}
