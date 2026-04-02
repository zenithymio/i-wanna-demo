using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
///陷阱类型：生成物体移动，物体位移，消除方块
///陷阱功能：前两次在陷阱位置生成预制体向上发射，第三次陷阱向上移动，清除地板
/// </summary>


public class Trap_1 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private int count = 0;//陷阱触发次数
    private AudioSource sound;//触发声音
    public AudioClip sound1;
    public AudioClip sound2;
    public GameObject pfabsParent;//所有预制体的父物体

    //前两次陷阱
    public GameObject trap0;//生成点
    public GameObject trap_pfab;//刺预制体
    private Vector2 speed = new(0, 10);//飞行速度


    //第三次
    public Rigidbody2D ob0;//移动物
    public Transform in0;//移动物的初始位置
    public float upRange;//移动范围
    private float speed_L = 2f;//移动速度

    //触发后清除的方块
    public GameObject f1;//原物体
    public GameObject f2;
    public GameObject f3;
    private GameObject n1;//预制体
    private GameObject n2;
    private GameObject n3;

    //重置后在原先方块位置生成新方块
    public Transform in1;
    public Transform in2;
    public Transform in3;
    public GameObject floor_pfab;//草方块预制体

    private bool FirstStrike = true;//第三处陷阱是否第一次触发（在整个游戏中）

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd)  && collision.transform.CompareTag("Player"))
        {
            if (count <= 2)//触发两次发射
            {
                sound.clip = sound1;
                GameObject trap1 = Instantiate(trap_pfab, trap0.transform.position, Quaternion.identity);//在刺的位置生成另一个刺发射出去
                trap1.GetComponent<Rigidbody2D>().velocity = speed;//赋予速度
                Destroy(trap1, 2.0f);//两秒后摧毁生成的预制体
                sound.Play();//播放触发音
            }
            if (count == 3)
            {
                sound.clip = sound2;
                ob0.velocity = Vector2.up * speed_L;
                StrikeEnd=true;//该陷阱已经全部触发结束
                if (FirstStrike)//若第一次触发，摧毁原方块
                {
                    Destroy(f1);
                    Destroy(f2);
                    Destroy(f3);
                    FirstStrike=false;
                    sound.Play();//播放触发音
                }
                else//若不是，摧毁预制体
                {
                    Destroy(n1);
                    Destroy(n2);
                    Destroy(n3);
                    sound.Play();//播放触发音
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player")&&(count<=2))
        {
            if (count <= 2)
            {
                count++;
            }
        }
    }

    private void Update()
    {
        StopOb();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    private void StopOb()//暂停移动物
    {
        if (ob0.transform.position.y > upRange)
        {
            ob0.velocity = new Vector2(0, 0);
        }
    }
    private void Reset()
    {
        ob0.position = in0.position;//移动的物体回到初始位置
        if (StrikeEnd)//触发过第三个陷阱
        {
            n1 = Instantiate(floor_pfab, in1.position, Quaternion.identity);
            n2 = Instantiate(floor_pfab, in2.position, Quaternion.identity);
            n3 = Instantiate(floor_pfab, in3.position, Quaternion.identity);
            //设置预制体的父物体
            n1.transform.parent = pfabsParent.transform;
            n3.transform.parent = pfabsParent.transform;
            n2.transform.parent = pfabsParent.transform;
        }
        StrikeEnd = false;
        count = 0;
    }
}

