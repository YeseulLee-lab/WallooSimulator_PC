using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderInteractable : MonoBehaviour
{
    public void MoveToLogin()
    {
        SceneSwitcher.Instance.SwitchScene(Define.SceneName.Login);
    }
}
