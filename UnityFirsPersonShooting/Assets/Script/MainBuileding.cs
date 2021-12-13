using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainBuileding : MonoBehaviour
{
    #region 
    public static Transform instance;
    private void Awake()
    {
        instance = this.transform;
    }

    #endregion
    [SerializeField] private LoseScreenBehaviour loseUI;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            EnemyController enemy = collider.GetComponent<EnemyController>();
            if(enemy.HaveBoom)
            {
                loseUI.Lose();
            }
        }
    }
    
}
