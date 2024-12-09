using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallooManager : MonoBehaviour
{
    public static WallooManager instance;

    private CustomInteractableBase _curWallooInteractable;

    private float _wallooScore;
    public float wallooScore
    {
        get
        {
            return _wallooScore;
        }
        set
        {
            _wallooScore = value;
            _wallooScoreChangedAction?.Invoke(_wallooScore);
        }
    }

    private float _doubtRate;
    public float doubtRate
    {
        get
        {
            return _doubtRate;
        }
        set
        {
            if (_doubtRate >= 100f)
            {
                _doubtRate = 100f;
                Debug.Log("게임종료");
            }
            else
            {
                _doubtRate = value;
                _doubtRateChangedAction?.Invoke(_doubtRate);
            }
        }
    }

    private bool _isWorkStart;
    public bool isWorkStart
    {
        get
        {
            return _isWorkStart;
        }
        set
        {
            _isWorkStart = value;
            _workStateChangedAction?.Invoke();
            UniTimer().Forget();
        }
    }

    private bool _isWallooing;
    public bool isWallooing
    {
        get
        {
            return _isWallooing;
        }
        set
        {
            _isWallooing = value;
        }
    }

    private bool _isCaught;
    public bool isCaught
    {
        get
        {
            return _isCaught;
        }
        set
        {
            _isCaught = value;
        }
    }

    public Action _workStateChangedAction{ private get; set; }
    public Action<float> _doubtRateChangedAction { private get; set; }
    public Action<float> _wallooScoreChangedAction{ private get; set; }

    public Queue<CustomInteractableBase> _interactableQueue = new Queue<CustomInteractableBase>();

    public Timer timer;
    private float _clearTime;
    public float clearTime
    {
        get
        {
            return _clearTime;
        }
        set
        {
            _clearTime = value;
        }
    }

    [SerializeField]
    private Transform _boss;
    public Transform Boss
    {
        get
        {
            return _boss;
        }
    }

    async UniTaskVoid UniTimer()
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            _clearTime += 1f;
        }
    }

    #region Unity Life Cycle
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitData();
        AudioManager.instance.PlayAmbientSound("OfficeAmbient");
    }
    #endregion

    private void InitData()
    {
    }
}
