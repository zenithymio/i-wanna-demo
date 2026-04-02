using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// 陷阱类型：消除方块
/// </summary>
public class Trap_8 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发声音
    //消除的方块
    public GameObject trap1;//原物体
    public GameObject trap2;
    private GameObject n1;//预制体
    private GameObject n2;

    //重置
    //生成位置
    public Transform in1;
    public Transform in2;
    //生成预制体
    public GameObject floor_pfab;
    public GameObject soil_pfab;

    public GameObject pfabsParent;
    private bool FirstStrike = true;//是否第一次触发（在整个游戏中）


    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;

            if (FirstStrike)
            {
                Destroy(trap1);
                Destroy(trap2);
                FirstStrike = false;
                sound.Play();//播放触发音
            }
            else
            {
                Destroy(n1);
                Destroy(n2);
                sound.Play();//播放触发音
            }
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
        if (StrikeEnd)
        {
            n1 = Instantiate(floor_pfab, in1.position, Quaternion.identity);
            n2 = Instantiate(soil_pfab, in2.position, Quaternion.identity);
            n1.transform.parent = pfabsParent.transform;
            n2.transform.parent = pfabsParent.transform;
        }
        StrikeEnd = false;
    }
}
