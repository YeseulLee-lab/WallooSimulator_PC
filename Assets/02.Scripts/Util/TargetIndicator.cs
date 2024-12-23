using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField]
    private Sprite _warningSP;
    [SerializeField]
    private Sprite _overSP;
    [SerializeField]
    private Sprite _defaultSP;

    public Transform player;
    public Camera activeCamera;
    public List<Indicator> targetIndicators;
    public GameObject indicatorPrefab;
    public float checkTime = 0.1f;
    public Vector2 offset;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        InstantiateIndicators();

        StartCoroutine(UpdateIndicators());
    }

    private void InstantiateIndicators()
    {
        foreach (var targetIndicator in targetIndicators)
        {
            if (targetIndicator.indicatorUI == null)
            {
                targetIndicator.indicatorUI = Instantiate(indicatorPrefab).transform;
                targetIndicator.indicatorUI.SetParent(_transform);
            }

            var rectTransform = targetIndicator.indicatorUI.GetComponent<RectTransform>();
            if (rectTransform == null)
            {
                rectTransform = targetIndicator.indicatorUI.gameObject.AddComponent<RectTransform>();
            }

            targetIndicator.rectTransform = rectTransform;
        }
    }

    private void UpdatePosition(Indicator targetIndicator)
    {
        var rect = targetIndicator.rectTransform.rect;

        //Get screen point from world point
        var indicatorPosition = activeCamera.WorldToScreenPoint(targetIndicator.target.position);

        //Handle if object is behind camera
        if (indicatorPosition.z < 0)
        {
            indicatorPosition.y = -indicatorPosition.y;
            indicatorPosition.x = -indicatorPosition.x;
        }
        var newPosition = new Vector3(indicatorPosition.x, indicatorPosition.y, indicatorPosition.z);

        //Set coordinates to show the object inside screen
        indicatorPosition.x = Mathf.Clamp(indicatorPosition.x, rect.width / 2, Screen.width - rect.width / 2) + offset.x;
        indicatorPosition.y = Mathf.Clamp(indicatorPosition.y, rect.height / 2, Screen.height - rect.height / 2) + offset.y;
        indicatorPosition.z = 0;

        
        targetIndicator.indicatorUI.position = indicatorPosition;

        if (Mathf.Abs( Vector3.Dot(targetIndicator.target.forward, (targetIndicator.target.position - player.position).normalized)) < 0.6f)
        {
            {
                targetIndicator.indicatorUI.GetComponent<Image>().sprite = _warningSP;
                targetIndicator.indicatorUI.up = Vector3.zero;

                if (WallooManager.instance.isWallooing)
                {
                    UIManager.instance.GameResult.ShowFailResult();
                    WallooManager.instance.isWallooing = false;
                }
            }
        }
        else
        {
            targetIndicator.indicatorUI.GetComponent<Image>().sprite = _defaultSP;
            //Update position and rotation
            targetIndicator.indicatorUI.up = (newPosition - indicatorPosition).normalized;
        }
    }

    private IEnumerator<float> UpdateIndicators()
    {
        while (true)
        {
            foreach (var targetIndicator in targetIndicators)
            {
                UpdatePosition(targetIndicator);
            }
            
            yield return checkTime;
        }
    }

    [Serializable]
    public class Indicator
    {
        public Transform target;
        public Transform indicatorUI;
        public RectTransform rectTransform;
    }
}
