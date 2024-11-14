using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class Timer : MonoBehaviour
{
    [Header("----------UI----------")]
    private TextMeshProUGUI _timeTMP;

    [Header("----------Timer----------")]
    //총 근무시간
    private float _time = 0f;
    private float _goalTime;
    private readonly Action _onTick;
    private float _timerSpeed = 1f;

    private int _minute;
    private int _hour;

    private CancellationTokenSource _workTimeCTS = new CancellationTokenSource();

    #region Unity Life Cycle
    private void Start()
    {
        _timeTMP = GetComponent<TextMeshProUGUI>();
        CalculateTime(0f);
        WallooManager.instance._workStateChangedAction = () => StartTimer();
    }
    #endregion

    #region Timer
    public void StartTimer()
    {
        UniTimer().Forget();
    }

    private void CalculateTime(float curTime)
    {
        //9시에 일 시작하므로 9를 더해줌
        _hour = ((int)curTime / 3600) + 9;
        _minute = (int)curTime / 60 % 60;

        _timeTMP.text = _hour.ToString("00") + ":" + _minute.ToString("00");

        if (_hour < 12)
        {
            _timeTMP.text += " AM";
        }
        else
        {
            _timeTMP.text += " PM";
        }
    }

    async UniTaskVoid UniTimer()
    {
        while (true)
        {
            if(_workTimeCTS.IsCancellationRequested)
                return;

            //총 근무시간이 9시간 미만이면
            if (_time < 32400f)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_timerSpeed), cancellationToken: _workTimeCTS.Token);
                _time += 6f;
                if (_time >= _goalTime)
                {
                    _timerSpeed = 1f;
                }
                CalculateTime(_time);
                _onTick?.Invoke();
            }
            else
            {
                Debug.Log("근무 종료");
                _workTimeCTS.Cancel();
            }
        }
    }

    public void SkipTime(float skipTime)
    {
        _goalTime = _time + skipTime;
        _timerSpeed = 0.01f;
    }
    #endregion
}
