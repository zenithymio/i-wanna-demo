using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 陷阱类型：物体位移
/// </summary>

public class Trap_2 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发音
    //移动物
    public Rigidbody2D ob1;
    public Rigidbody2D ob2;
    //移动物初始位置
    public Transform in1;
    public Transform in2;
    //移动速度
    private float speed = 12;
    //移动范围
    public float rightRange;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd= true;
            ob1.velocity= Vector2.right*speed;
            ob2.velocity= Vector2.right*speed;
            sound.Play();
        }
    }

    private void Update()
    {
        Test();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    private void Test()
    {
        if (ob1.transform.position.x>rightRange)
        {
            ob1.velocity = new Vector2(0, 0);
            ob2.velocity = new Vector2(0, 0);
        }
    }
    private void Reset()
    {
        ob1.position = in1.position;
        ob2.position = in2.position;
        StrikeEnd = false;
    }
}
