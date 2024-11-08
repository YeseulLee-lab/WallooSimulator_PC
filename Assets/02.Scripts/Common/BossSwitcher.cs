using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _bossArr;

    private int _curIdx = 0;

    private void Start()
    {
        _bossArr[_curIdx].SetActive(true);
    }

    public void SwitchBoss()
    {
        if (_curIdx < 2)
            _curIdx++;
        else
            _curIdx = 0;

        for (int i = 0; i < 3; i++)
        {
            _bossArr[i].SetActive(false);
        }

        _bossArr[_curIdx].SetActive(true);
    }
}
