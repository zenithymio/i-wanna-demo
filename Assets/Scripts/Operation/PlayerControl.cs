using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    //窗口管理
    public GameWindow gameWindow;
    //private DataControl dataController;

    //角色
    public float speed;//移动速度
    private Vector3 playerScale;//缩放
    private CapsuleCollider2D playerFeet;//脚部判定
    private Rigidbody2D playerRigidbody;//刚体
    private Animator playerAni;//动画
    private AudioSource playMusic;

    //跳跃
    public float jumpSpeed1;//一段跳速度
    public float jumpSpeed2;//二段跳速度
    private int jumpCount = 2;//最大跳跃次数
    public AudioClip musicJump;//音效

    //射击
    public GameObject bullet;//子弹预制体
    private bool playerFacingRight = true;//朝向
    private Vector2 bulletSpeed = new(15, 0);//子弹飞行速度
    public AudioClip musicShot;//音效

    public void InitPlayer()//初始化
    {
        playerScale = transform.localScale;
        playerFeet = GetComponent<CapsuleCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        playMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Fall();
        IfOnLand();
        Shot();
    }

    private void Run()//移动
    {
        if (Input.GetKey(KeyCode.RightArrow))//右移
        {
            transform.localScale = playerScale;
            playerRigidbody.velocity =new Vector2(speed,playerRigidbody.velocity.y);
            playerAni.SetBool("IfRun", true);
            playerFacingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))//左移
        {
            transform.localScale=new Vector3(-playerScale.x,playerScale.y,playerScale.z);
            playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
            playerAni.SetBool("IfRun", true);
            playerFacingRight=false;
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            playerAni.SetBool("IfRun", false);
        }
    }

    private void Jump()//跳跃
    {
        if (Input.GetKeyDown(KeyCode.Space)&&jumpCount!=0)
        {
            playMusic.clip=musicJump;
            playMusic.volume = 0.8f;
            playMusic.Play();
            playerAni.SetBool("IfIdle", false);
            playerAni.SetBool("IfFall", false);
            playerAni.SetBool("IfJump", true);
            if (jumpCount == 2)
            {
                playerRigidbody.velocity = Vector2.up * jumpSpeed1;
            }
            else if(jumpCount == 1)
            {
                playerRigidbody.velocity = Vector2.up * jumpSpeed2;
                jumpCount--;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))//按的时间越长，跳的越高
        {
            if(playerRigidbody.velocity.y > 3f)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 3f);
            }
        }
    }

    private void Fall()//下落
    {
        if (playerRigidbody.velocity.y <= 0f)
        {
            playerAni.SetBool("IfIdle", false);
            playerAni.SetBool("IfJump", false);
            playerAni.SetBool("IfFall", true);
        }
        if(playerRigidbody.velocity.y < -8f)//下落到一定速度后，匀速下落
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -8f);
        }
    }
    private void IfOnLand()//判定地面（辅助跳跃）
    {
        if(playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpCount =2;//重置跳跃次数
            if (playerAni.GetBool("IfFall")is true)
            {
                playerAni.SetBool("IfFall", false);
                playerAni.SetBool("IfIdle", true);
            }
        }
        else if(jumpCount==2)
        {
            jumpCount--;//从平地掉落至空中，只能跳一次
        }

    }

    private void Shot()//射击
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playMusic.clip = musicShot;
            playMusic.volume = 0.8f;
            playMusic.Play();
            GameObject Bullet= Instantiate(bullet,transform.position,Quaternion.identity);//在人物位置生成子弹
            Bullet.GetComponent<Rigidbody2D>().velocity=playerFacingRight?bulletSpeed:-bulletSpeed;//速度赋值
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//碰到Tag="Spike"执行游戏结束
    {
        if (collision.transform.CompareTag("Spike"))
        {
            gameWindow.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰到Tag="Warp"跳转下一关
    {
        if (collision.transform.CompareTag("Warp"))
        {
            collision.SendMessage("NextLevel", SendMessageOptions.DontRequireReceiver);
        }
    }

    /*private void IfOnSaveSwitch()
    {
        if (playerRigidbody.IsTouchingLayers(LayerMask.GetMask("SaveSwitch")))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Transform saveSwitches = transform.parent.GetChild(3).Find("SaveSwitches");
                Transform switchNear = saveSwitches.GetChild(0);
                float distance = Vector3.Distance(switchNear.position, transform.position);
                for (int i = 1; i < saveSwitches.childCount; i++)
                {
                    Vector3 switchTemp = saveSwitches.GetChild(i).position;
                    if (Vector3.Distance(switchTemp, transform.position) < distance)
                    {
                        switchNear = saveSwitches.GetChild(i);
                        distance = Vector3.Distance(switchNear.position, transform.position);
                    }
                }
                switchNear.GetComponent<Animator>().Play("SaveLight");
                dataController.SetSavePosition(gameWindow.levelCountTemp, transform.localPosition);
            }
        }
    }*/
}
