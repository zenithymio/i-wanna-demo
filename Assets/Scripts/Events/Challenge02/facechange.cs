using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class facechange : MonoBehaviour
{
    private bool StrikeEnd = false;
    public SpriteRenderer spritePicture;
    public Sprite unhappy;
    public Sprite hate;
    public GameObject cherry_pfab;
    public GameObject Nahida;
    public Transform obj;
    private AudioSource sound;//¥•∑¢“Ù
    private GameObject player;
    private bool createCherry=false;
    private float spawnTime = 2.0f;
    private float Delta = 0;
    private float moveSpeed = 3.2f;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!StrikeEnd) && collision.transform.CompareTag("Player"))
        {
            StrikeEnd = true;
            spritePicture.sprite = hate;
            sound.Play();
            createCherry= true;
        }
    }

    private void Update()
    {
        Cherry();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    private void Reset()
    {
        StrikeEnd= false;
        spritePicture.sprite = unhappy;
        createCherry= false;
    }

    private void Cherry()
    {
        if (createCherry)
        {
            Delta += Time.deltaTime;
            if (Delta > spawnTime)
            {
                if (player.activeSelf)
                {
                    Transform now = obj;
                    GameObject cherry = Instantiate(cherry_pfab, Nahida.transform.position, Quaternion.identity);
                    cherry.GetComponent<Rigidbody2D>().velocity = new Vector2(now.position.x, now.position.y).normalized * moveSpeed;
                    Destroy(cherry, 4.0f);
                }
                Delta = 0;
            }
        }
    }
}
