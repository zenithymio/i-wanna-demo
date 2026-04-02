using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 陷阱类型：生成物体
/// </summary>
public class Trap_9 : MonoBehaviour
{
    private bool StrikeEnd = false;
    private AudioSource sound;//触发声音
    //生成点
    public Transform in1;
    public Transform in2;
    public Transform in3;
    //生成物
    private GameObject n1;
    private GameObject n2;
    private GameObject n3;
    //预制体
    public GameObject floor_pfab;
    public GameObject soil_pfab;
    public GameObject pfabsParent;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;//后续触碰不再生成新物体
            n1 = Instantiate(floor_pfab, in1.position, Quaternion.identity);
            n2 = Instantiate(soil_pfab, in2.position, Quaternion.identity);
            n3 = Instantiate(soil_pfab, in3.position, Quaternion.identity);
            n1.transform.parent = pfabsParent.transform;
            n2.transform.parent = pfabsParent.transform;
            n3.transform.parent = pfabsParent.transform;
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
        if (StrikeEnd)
        {
            Destroy(n1);
            Destroy(n2);
            Destroy(n3);
        }
        StrikeEnd = false;
    }


}
