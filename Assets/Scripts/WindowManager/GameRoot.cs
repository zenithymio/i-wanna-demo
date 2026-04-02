using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;

    public StartWindow startwindow;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        ClearWindow();
        InitGame();
    }

    private void ClearWindow()//隐藏startwindow以外的窗口
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false); 
        }
        startwindow.SetwindowState(true);
    }

    private void InitGame()
    {
        ResourceSvc resourceSvc=GetComponent<ResourceSvc>();
        resourceSvc.InitSvc();

        DataControl dataController = GetComponent<DataControl>();
        dataController.InitController();
    }
}
