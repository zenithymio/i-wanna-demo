using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWindow : WindowRoot
{
    public RecordWindow recordWindow;

    protected override void InitWindow()//初始化资源服务
    {
        base.InitWindow();
    }
    // Update is called once per frame
    private void Update()
    {
        EnterRecordWindow();
    }
    private void EnterRecordWindow()//按[Space]进入存档界面
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetwindowState(false);
            recordWindow.SetwindowState(true);
        }
    }
}
