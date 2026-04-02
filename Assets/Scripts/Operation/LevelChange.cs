using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{   
        public Level levelPresrnt;
        public Level levelNext;
        public GameObject BirthPostion;
        private GameObject player;
        private void Start()
        {
            player = GameObject.Find("Player");
        }
        public void NextLevel()
        {
            levelPresrnt.SetwindowState(false);
            levelNext.SetwindowState(true);
            player.transform.position = BirthPostion.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", BirthPostion.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", BirthPostion.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", BirthPostion.transform.position.z);
        }
}
