using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
public class ResourceSvc : MonoBehaviour
{
    public static ResourceSvc Instance;

    public XmlDocument dataDocument;
    public XmlNodeList dataNodeList;

    private Dictionary<string, AudioClip> AudioDic = new Dictionary<string, AudioClip>();
    public void InitSvc()
    {
        Instance = this;
        InitSaveData();
    }

    private void InitSaveData()//初始化存档信息
    {
        StreamReader xmlFile = new StreamReader(Application.dataPath + PathDefine.saveDataCfgComplete);
        dataDocument = new XmlDocument();
        dataDocument.LoadXml(xmlFile.ReadToEnd());
        dataNodeList = dataDocument.SelectSingleNode("data").ChildNodes;
    }

    public struct SaveData//存档信息
    {
        public string state;
        public int deathCount;
        public string time;
        public string savePosition;
    }
    public SaveData GetSaveData(int dataChooseNum)//获取存档
    {
        XmlElement element = (XmlElement)dataNodeList[dataChooseNum];
        SaveData saveData = new SaveData();
        saveData.state = element.GetAttribute("state");
        saveData.deathCount = int.Parse(element.GetAttribute("death"));
        saveData.time = element.GetAttribute("time");
        saveData.savePosition = element.GetAttribute("save_position");
        return saveData;
    }
    public AudioClip LoadAudio(string audioName)
    {
        if (!AudioDic.TryGetValue(audioName, out AudioClip clip))
        {
            clip = Resources.Load<AudioClip>("Audio/" + audioName);
            AudioDic.Add(audioName, clip);
        }
        return clip;
    }
}
