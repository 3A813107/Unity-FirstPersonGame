using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetup : MonoBehaviour
{
    public Transform boomPos;
    void Start()
    {
        GameManager.isPause = false;
        GameManager.instance.Lose = false;
        GameManager.instance.WaveKillNum=0;
        GameManager.instance.PlayerMoney=0;
        GameManager.instance.PlayerDie = false;
        GameManager.instance.currentBoomPos=boomPos.transform.position;        
    }

}
