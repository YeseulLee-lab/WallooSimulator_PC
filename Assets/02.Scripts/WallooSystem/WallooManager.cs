using System;
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
                Debug.Log("��������");
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

    public Timer timer;

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
