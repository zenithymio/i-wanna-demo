using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    public Sprite strikeSuccess;
    public Sprite strikeFailure;
    protected bool Alter=false;
    SpriteRenderer spritePicture;
    public SpriteRenderer Nahida;
    public Sprite black;
    public GameObject spike;
    public GameObject spikeAlter;
    private AudioSource sound;//¥•∑¢“Ù
    void Awake()
    {
        spritePicture=GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
    }

    private void BeShot()
    {
        spritePicture.sprite = strikeSuccess;
        Alter= true;
        sound.Play();
        Nahida.sprite = black;
        spike.SetActive(false);
        spikeAlter.SetActive(true);
    }
    private void Update()
    { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reset();
            }
    }
    private void Reset() { 
        spritePicture.sprite = strikeFailure;
        Alter= false;
        spike.SetActive(true);
        spikeAlter.SetActive(false);
    }
}
