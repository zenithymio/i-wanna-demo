using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 陷阱类型：消除方块
/// </summary>
public class Trap_4 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发声音
    public GameObject pfabsParent;

    //触发后清除的方块
    public GameObject trap1;//原物体
    public GameObject trap2;
    public GameObject trap3;
    private GameObject n1;//预制体
    private GameObject n2;
    private GameObject n3;

    //重置后生成的位置
    public Transform in1;//原点
    public Transform in2;
    public Transform in3;
    //预制体
    public GameObject floor_pfab;
    public GameObject soil_pfab;

    private bool FirstStrike = true;//是否第一次触发
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd)  && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            if (FirstStrike)
            {
                Destroy(trap1);
                Destroy(trap2);
                Destroy(trap3);            
                FirstStrike=false;
                sound.Play();//播放触发音
            }
           else
            {
                Destroy(n1);
                Destroy(n2);
                Destroy(n3);
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
            n2 = Instantiate(floor_pfab, in2.position, Quaternion.identity);
            n3 = Instantiate(soil_pfab, in3.position, Quaternion.identity);
            n1.transform.parent = pfabsParent.transform;
            n2.transform.parent = pfabsParent.transform;
            n3.transform.parent = pfabsParent.transform;
        }
        StrikeEnd = false;
    }
}
    
