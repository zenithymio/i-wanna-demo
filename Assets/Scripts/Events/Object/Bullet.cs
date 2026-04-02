using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        IfOutRange();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("BeShot", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
    private void IfOutRange()//预防部分子弹未清理
    {
    if(gameObject.transform.transform.position.x<-30f|| gameObject.transform.transform.position.x > 30f)
        {
            Destroy(gameObject);
        }
    }
}
