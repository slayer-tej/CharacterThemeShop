using System;
using UnityEngine;
using UnityEngine.UI;

public enum Status
{
    Locked,
    Unlocked,
    Selected
}


public class ServiceLobby : MonoBehaviour
{
    public static ServiceLobby current;
    public event Action<string> OnCharChange;

    private void Awake()
    {
        current = this;
    }
   
    public void ChangeName(string name)
    {
        if(OnCharChange != null)
        {
            OnCharChange(name);
        }
    }
}
