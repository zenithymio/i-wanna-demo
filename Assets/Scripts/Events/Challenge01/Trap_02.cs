using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_02 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发音
    //出现的物体
    public GameObject FlashObj;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        FlashObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            FlashObj.SetActive(true);
            Invoke("Disappear", 3.0f);
            sound.Play();//播放触发音
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    private void Reset()
    {
        StrikeEnd = false;
        Disappear();
    }

    private void Disappear()
    {
        FlashObj.SetActive(false);
    }
}
