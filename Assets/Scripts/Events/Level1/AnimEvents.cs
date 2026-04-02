using UnityEngine;
/// <summary>
///作用：在动画过程中调用事件，实现一个机关多次触发音
///
/// 
///使用方法：挂载到播放动画的物体上，在动画控制器中选择事件
/// </summary>


public class AnimEvents : MonoBehaviour
{
    public Sprite jpg1;
    public Sprite jpg2;
    public Sprite jpg3;
    public Sprite jpg4;
    private AudioSource sound;//触发声音
    SpriteRenderer spritePicture;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        spritePicture= GetComponent<SpriteRenderer>();
    }
    public void Playsound()//播放声音
    {
        sound.Play();  
    }
    public void ChangeDown() 
    {
        spritePicture.sprite = jpg2;
    }
    private void ChangeUp()
    {
        spritePicture.sprite = jpg1;
    }

    private void ChangeLaugh()
    {
        spritePicture.sprite = jpg3;
    }
    private void ChangeSweat()
    {
        spritePicture.sprite = jpg4;
    }
}
