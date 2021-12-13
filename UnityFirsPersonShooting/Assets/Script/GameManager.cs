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
    
    public GameObject playerPrefab;
    public Transform SpawnPoint;

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
        Instantiate(playerPrefab, SpawnPoint.position,Quaternion.identity);
    }

}
