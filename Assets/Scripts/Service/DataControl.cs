using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    public static DataControl Instance;

    public static string state;
    public static int deathCount;
    public static int hour;
    public static int minute;
    public static int second;
    public static int levelCount;
    public static float savePosX;
    public static float savePosY;

    private ResourceSvc resSvc;
    private XmlElement element;

    private int dataChooseNum;

    public void InitController()
    {
        Instance = this;
    }

    public void InitData(int dataChooseNum)
    {
        resSvc = ResourceSvc.Instance;
        element = (XmlElement)resSvc.dataNodeList[dataChooseNum];
        this.dataChooseNum = dataChooseNum;
        RefreshData();
    }

    public void RefreshData()
    {
        ResourceSvc.SaveData saveData = resSvc.GetSaveData(dataChooseNum);
        state = saveData.state;
        deathCount = saveData.deathCount;

        string[] saveTime = saveData.time.Split(':');
        hour = int.Parse(saveTime[0]);
        minute = int.Parse(saveTime[1]);
        second = int.Parse(saveTime[2]);

        string[] savePosition = saveData.savePosition.Split(',');
        levelCount = int.Parse(savePosition[0]);
        savePosX = float.Parse(savePosition[1]);
        savePosY = float.Parse(savePosition[2]);
    }

    public void SetState(string state)
    {
        element.SetAttribute("state", state);
        RefreshData();
        Save();
    }

    public void SetDeathCount(int deathCount)
    {
        element.SetAttribute("death", deathCount.ToString());
        RefreshData();
        Save();
    }

    public void SetTime(string time)
    {
        element.SetAttribute("time", time);
        RefreshData();
        Save();
    }

    public void SetSavePosition(int levelCount, Vector2 position)
    {
        string saveDataTemp = string.Format("{0},{1},{2}", levelCount, position.x, position.y);
        element.SetAttribute("save_position", saveDataTemp);
        RefreshData();
        Save();
    }

    private void Save()
    {
        string path = Application.dataPath + PathDefine.saveDataCfgComplete;
        resSvc.dataDocument.Save(path);
    }
}

