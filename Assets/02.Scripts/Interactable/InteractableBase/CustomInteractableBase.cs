using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Outline))]
public class CustomInteractableBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //오브젝트 데이터
    [SerializeField]
    protected InteractableData _interactableData;
    protected Transform originTransform;
    protected bool _isWallooing;

    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private AudioClip _interactionAC;

    //coolTime
    protected float _curCoolTime = 0f;
    protected CancellationTokenSource _coolTimeCancel = new CancellationTokenSource();

    #region Unity Life Cycle
    protected virtual void Start()
    {
        if(GetComponent<Animator>() != null)
            _animator = GetComponent<Animator>();
        GetComponent<Outline>().enabled = false;

        Color color;
        ColorUtility.TryParseHtmlString("#9BFFAF", out color);
        GetComponent<Outline>().OutlineColor = color;
        GetComponent<Outline>().OutlineWidth = 4f;

        originTransform = transform;
    }
    #endregion

    #region Interact
    public virtual void PlayWallooAction()
    {
        //쿨타임이 다 찼으면 월루 행동 가능
        if (_curCoolTime <= 0f)
        {
            Debug.Log("월루 행동시작");
            _isWallooing = true;

            AudioManager.instance.PlaySound(_interactionAC);

            if (_interactableData != null)
            {
                WallooManager.instance.doubtRate += _interactableData.doubtRate;
                WallooManager.instance.wallooScore += _interactableData.wallooScore;
            }
                
            if (_animator != null)
            {
                _animator.SetBool("isWallooing", true);
                _animator.enabled = true;
            }
            

            UniCoolTime().Forget();
        }
        else
        {
            Debug.Log("아직 쿨타임이 안찼습니다.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //바닥에 닿으면 원래자리로 돌아감
        if (collision.gameObject.layer == 0)
        {
            gameObject.transform.position = originTransform.position;
            gameObject.transform.rotation = originTransform.rotation;
        }
    }
    #endregion

    #region CoolTime
    public async UniTaskVoid UniCoolTime()
    {
        if (_interactableData != null)
        {
            while (_interactableData.coolTime > 0f)
            {
                if (_coolTimeCancel.IsCancellationRequested)
                {
                    _coolTimeCancel = new CancellationTokenSource();
                    return;
                }

                if (_curCoolTime < _interactableData.coolTime)
                {
                    //총 쿨타임 만큼 _curCoolTime 플러스
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _coolTimeCancel.Token);
                    _curCoolTime += 1f;
                    Debug.Log(_interactableData.name + "쿨타임: " + _curCoolTime);
                }
                else
                {
                    _coolTimeCancel.Cancel();
                    Debug.Log("unitask 취소");
                    _curCoolTime = 0f;
                    _isWallooing = false;
                }
            }
        }
    }
    #endregion

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Outline>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Outline>().enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_animator != null)
            _animator.SetBool("isWallooing", false);

        PlayWallooAction();
    }
    #endregion
}

