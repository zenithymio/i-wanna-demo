using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : WindowRoot
{
    //关卡
    public GameObject player;//玩家
    public Transform InitPosition;//初始位置

    //窗口管理
    //public PlayerControl playerctl;
    public GameObject gameOverTip;//游戏结束标识
    public GameObject playerDied;//死亡动画
    private AudioSource bgm;//背景音乐
    private bool ifcount=false;

    //死亡计数器，计时器相关
    public Text death;
    protected int deathCount = 0;
    private int hour = 0;
    private int minute = 0;
    private int second = 0;
    private float tsec = 0;

    protected override void InitWindow()//初始化
    {
        //关卡初始化
        base.InitWindow();
        bgm = GetComponent<AudioSource>();
        GameStart();
        //玩家位置初始化
        player.transform.position = InitPosition.position;
        PlayerPrefs.SetFloat("PlayerPosX", InitPosition.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", InitPosition.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", InitPosition.position.z);
    }
    protected override void ClearWindow()
    {
        base.ClearWindow();
    }

    private void GameStart()//游戏开始
    {
        player.SetActive(true);//玩家显示
        gameOverTip.SetActive(false);//结束标识关闭
        bgm.enabled = true;
    }
    public void GameOver()//游戏结束
    {
        
        bgm.enabled = false;
        player.SetActive(false);//关闭玩家显示
        Instantiate(playerDied, player.transform.position, Quaternion.identity);
        gameOverTip.SetActive(true);//显示标识
        
    }
    private void Update()
    {
        DeathCounter();
        tsec += Time.deltaTime;
        GameTimer();
        death.text = "    <color=\"#FF0000\">"+"Death:" + deathCount.ToString()+"</color>"+"\n"+"    Time:"+hour.ToString()+":"+minute.ToString()+":"+second.ToString();
        Rebirth();
    }

    private void Rebirth()//按"R"重生
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameStart();
            LoadPosition();
            ifcount = false;
        }
    }
    private void LoadPosition()//加载玩家至上次存档位置
    {
        float x = PlayerPrefs.GetFloat("PlayerPosX", 0);
        float y = PlayerPrefs.GetFloat("PlayerPosY", 0);
        float z = PlayerPrefs.GetFloat("PlayerPosZ", 0);
        player.transform.position = new Vector3(x, y, z);
    }

    private void GameTimer()//时间转换
    {
        if (tsec >= 1)
        {
            second++;
            tsec = 0;
        }
        if (second >= 60)
        {
            minute++;
            second = 0;
        }
        if (minute >= 60)
        {
            hour++;
            minute = 0;
        }
    }

    private void DeathCounter()
    {
        if ((player.activeSelf == false)&&(ifcount == false))
        {
            deathCount++;
            ifcount = true;
        }
    }
}
