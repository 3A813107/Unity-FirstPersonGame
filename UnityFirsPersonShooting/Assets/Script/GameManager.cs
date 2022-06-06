using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isboomTaking = false;

    public static bool isPause = false;

    public int PlayerMoney;
    public int WaveKillNum;

    public Vector3 currentBoomPos;
    public Vector3 BoomPos;
    public bool Lose = false;
    
    public bool PlayerDie = false;

    public float respawnTime = 5f;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        BoomPos=currentBoomPos;
    }

    public void SpawnPlayer()
    {

    }

}
