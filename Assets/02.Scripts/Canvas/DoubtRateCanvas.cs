using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubtRateCanvas : MonoBehaviour
{
    [Header("----------GUI----------")]
    [SerializeField]
    private Image _doubtRateBar;

    #region Unity Life Cycle
    private void Start()
    {
        WallooManager.instance._doubtRateChangedAction = (rate) => DoubtRateChange(rate);
    }
    #endregion

    private void DoubtRateChange(float doubtRate)
    {
        _doubtRateBar.fillAmount = doubtRate * 0.01f;
    }
}
