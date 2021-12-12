using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHUD : MonoBehaviour
{
    [SerializeField] private WaveUI waveUI;
    [SerializeField] private WaveBar waveBar;
    public GameObject WaveTime;

    public void UpdateWaveUI(int TotalWave,int currentWave)
    {        
        waveUI.UpdateWave(TotalWave,currentWave);
    }
    public void UpdateWaveTime(int WaveCountdown,Color color)
    {
        waveUI.UpdataeWaveTime(WaveCountdown,color);
    }

    public void UpdateWaveBar(int currentEnemy,int totalEnemy)
    {
        waveBar.SetValue(currentEnemy,totalEnemy);
    }
}
