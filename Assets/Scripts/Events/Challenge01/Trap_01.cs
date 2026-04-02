using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_01 : MonoBehaviour
{
    private bool Event1End = false;
    private bool Event2End = false;
    private AudioSource sound;//触发音
    //播放动画的物体
    public GameObject AnimPlayer;
    //动画
    public Animator Animator;
    private GameObject player;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!Event1End&&!Event2End) && collision.transform.CompareTag("Player"))
        {
            Animator.Play("Anim 1", 0, 0);
            Event1End= true;
            Invoke("Event2", 4.8f);
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
        Event1End = false;
        Event2End = false;
    }
    private void Event2()
    {
        if(player.activeSelf&&(Event1End) ){
            Animator.Play("SoLarge", 0, 0);
            Event2End= true;
        }
    }
}
