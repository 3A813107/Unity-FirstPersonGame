using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text WaveNum;
    public Text WaveTime;

    public void UpdateWave(int totalWave,int currentWave)
    {
        WaveNum.text = "第"+currentWave+"/"+totalWave+"波"; 
    }

    public void UpdataeWaveTime(int Time,Color color)
    {
        WaveTime.color = color;
        WaveTime.text = Time.ToString();
    }
}
