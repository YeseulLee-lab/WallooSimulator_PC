using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "InteractableData")]
public class InteractableData : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _skipTime; //∫– ¥‹¿ß
    [SerializeField]
    private int _wallooScore;
    [SerializeField]
    private float _doubtRate;
    [SerializeField]
    private float _coolTime;

    public new string name
    {
        get { return _name; }
    }

    public float skipTime
    {
        get
        {
            return _skipTime;
        }
    }

    public float wallooScore
    {
        get
        {
            return _wallooScore;
        }
    }

    public float doubtRate
    {
        get
        {
            return _doubtRate;
        }
    }

    public float coolTime
    {
        get
        {
            return _coolTime;
        }
    }
}
