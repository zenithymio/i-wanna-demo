using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// 陷阱类型：物体位移
/// </summary>
public class Trap_5 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;
    //移动物
    public Rigidbody2D ob1;
    //移动物初始位置
    public Transform in1;
    //移动速度
    private float speed = 24f;
    //移动范围
    public float rightRange;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd)  && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            ob1.velocity = Vector2.right * speed;
            sound.Play();//播放触发音
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
        if (ob1.transform.position.x > rightRange)
        {
            ob1.velocity = new Vector2(0, 0);
        }
    }
    private void Reset()
    {
        ob1.position = in1.position;
        StrikeEnd = false;
    }
}
