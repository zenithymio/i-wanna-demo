using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 陷阱类型：播放动画
/// </summary>

public class Trap_3 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发音
    //播放动画的物体
    public GameObject trap0;
    //动画
    public Animator Animator;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd)  && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            Animator.Play("Spike_4", 0, 0);
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
    }
}
