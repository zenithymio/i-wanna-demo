using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// 陷阱类型：物体位移
/// </summary>

public class ObMove : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发音
    //移动物
    public Rigidbody2D Move_Obj1;
    //移动物初始位置
    public Transform Init_Pos1;
    //移动速度
    private float speed = 12;
    //移动范围
    public float Range;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();//获取音源
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            Move_Obj1.velocity = Vector2.right * speed;//赋予向右的速度
            sound.Play();
        }
    }
    private void Update()
    {
        Range_Dete();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    private void Range_Dete()
    {
        if (Move_Obj1.transform.position.x > Range)
        {
            Move_Obj1.velocity = new Vector2(0, 0);//速度为0
        }
    }
    private void Reset()
    {
        Move_Obj1.position = Init_Pos1.position;
        StrikeEnd = false;
    }
}
