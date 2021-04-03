using UnityEngine;

public class ControllerCharacterLock : MonoBehaviour
{
    public int unlockedAtLevel;
    public bool unlocked = false;
    public bool isSelected = false;
    public GameObject lockObject;

    public void Unlock()
    {
        unlocked = true;
    }
    public void Select(bool status)
    {
        isSelected = status;
    }

}

