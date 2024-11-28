using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorCanvas : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField]
    private TextMeshProUGUI _wallooScoreText;
    [SerializeField]
    private Button _youtubeBtn;
    [SerializeField]
    private Button _workBtn;
    [SerializeField]
    private Button _offBtn;

    [Header("Timer")]
    [SerializeField]
    private Timer _timer;

    #region Unity Life Cycle
    private void Start()
    {
        Init();
        WallooManager.instance._wallooScoreChangedAction = (score) => UpdateWallooScore(score);
    }
    #endregion

    private void Init()
    {
        _wallooScoreText.text = WallooManager.instance.wallooScore.ToString();
    }

    private void UpdateWallooScore(float wallooScore)
    {
        _wallooScoreText.text = wallooScore.ToString();
    }
}
