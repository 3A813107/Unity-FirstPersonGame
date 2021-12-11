using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isboomTaking = false;

    public int PlayerMoney;

    public Vector3 currentBoomPos;

    public GameObject playerPrefab;
    public Transform SpawnPoint;

    public Transform mainbuild;

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

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, SpawnPoint.position,Quaternion.identity);
    }

}
