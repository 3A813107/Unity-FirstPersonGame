using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReSpawnUI : MonoBehaviour
{
    public Text timer;

    public void UpdateRespawnTimer(float time)
    {
        int intTime=(int)time;
        timer.text = intTime.ToString();
    }
}
