using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerMiddlePanel : MonoBehaviour
{
    [SerializeField] private Text charNameField;

    private void Start()
    {
        ServiceLobby.current.OnCharChange += ChangeName;
    }

    private void ChangeName(string name)
    {
        charNameField.text = name;
    }
}
