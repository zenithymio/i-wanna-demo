using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRoot : MonoBehaviour
{
    protected ResourceSvc resourceSvc;
    protected DataControl dataController;
    public void SetwindowState(bool ifActive)//设置窗口激活状态
    {
        if (gameObject.activeSelf != ifActive)
        {
            gameObject.SetActive(ifActive);
        }
        if (ifActive)
        {
            InitWindow();
        }
        else
        {
            ClearWindow();
        }
    }

    protected virtual void InitWindow()//加载资源服务
    {
        resourceSvc = ResourceSvc.Instance;
        dataController = DataControl.Instance;
    }

    protected virtual void ClearWindow()//不加载
    {
        resourceSvc=null;
        dataController = null;
    }
}
