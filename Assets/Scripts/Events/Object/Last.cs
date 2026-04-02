using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Last : MonoBehaviour
{
    public TMP_Text words;

    IEnumerator TypeText(TMP_Text tMP_Text,string str,float interval)
    {
        int i=0;
        while (i <= str.Length)
        {
            tMP_Text.text = str.Substring(0,i++);
            yield return new WaitForSeconds(interval);
        }
    }

    private void Awake()
    {
        StartCoroutine(TypeText(words,"Congratulations!Let 's begin our theme ",0.15f));   
    }
}
