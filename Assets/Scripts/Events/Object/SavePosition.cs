using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    public Sprite saveSuccess;
    public Sprite saveFailure;

    SpriteRenderer spritePicture;
    // Start is called before the first frame update
    void Awake()
    {
        spritePicture = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void BeShot()
    {
        PlayerPrefs.SetFloat("PlayerPosX",transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
        spritePicture.sprite=saveSuccess;
        Invoke("Res", 0.5f);
    }

    private void Res() {
        spritePicture.sprite=saveFailure;
    } 
}
