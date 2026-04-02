using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : WindowRoot
{
    public Transform Leap;
    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            PlayerPrefs.SetFloat("PlayerPosX", Leap.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", Leap.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", Leap.position.z);
        }
    }
}
