using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Outline))]
public class CustomInteractableBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    //������Ʈ ������
    [SerializeField]
    protected InteractableData _interactableData;
    protected Transform originTransform;
    protected bool _isWallooing;

    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private AudioClip _interactionAC;

    [Header("--------CoolTime--------")]
    [SerializeField]
    private Image _coolTimeImg;
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
        //��Ÿ���� �� á���� ���� �ൿ ����
        if (_curCoolTime <= 0f)
        {
            Debug.Log("���� �ൿ����");
            if (_animator != null)
                _animator.SetBool("isWallooing", true);

            AudioManager.instance.PlaySound(_interactionAC);
            if(_interactableData?.coolTime > 0f)
                _coolTimeImg.DOFillAmount(1f, _interactableData.coolTime).SetEase(Ease.Linear);

            if (_interactableData != null)
            {
                WallooManager.instance.timer.SkipTime(_interactableData.skipTime);
                WallooManager.instance.doubtRate += _interactableData.doubtRate;
                WallooManager.instance.wallooScore += _interactableData.wallooScore;
            }
            
            UniCoolTime().Forget();
        }
        else
        {
            PopupManager.Instance.MouseToast.ShowToast("���� ��Ÿ���� ��á���ϴ�.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�ٴڿ� ������ �����ڸ��� ���ư�
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
                    //�� ��Ÿ�� ��ŭ _curCoolTime �÷���
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _coolTimeCancel.Token);
                    _curCoolTime += 1f;
                    //Debug.Log(_interactableData.name + "��Ÿ��: " + _curCoolTime);
                }
                else
                {
                    _coolTimeCancel.Cancel();
                    //Debug.Log("unitask ���");
                    _coolTimeImg.fillAmount = 0f;
                    ResetObject();
                    _curCoolTime = 0f;
                }
            }
        }
    }

    protected virtual void ResetObject()
    {

    }
    #endregion

    #region EventSystem

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (WallooManager.instance.isWorkStart)
            GetComponent<Outline>().enabled = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (WallooManager.instance.isWorkStart)
            GetComponent<Outline>().enabled = false;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (WallooManager.instance.isWorkStart)
        {
            PlayWallooAction();
            WallooManager.instance.isWallooing = true;
        }
        else
        {
            PopupManager.Instance.MouseToast.ShowToast("����͸� �Ѿ� �ٹ��� �����մϴ�!");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_animator != null)
        {
            _animator.SetBool("isWallooing", false);
            WallooManager.instance.isWallooing = false;
        }
    }
    #endregion
}

