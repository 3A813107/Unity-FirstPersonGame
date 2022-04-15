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
            EnemyController_shoot enemy = collider.GetComponent<EnemyController_shoot>();
            if(enemy.HaveBoom)
            {
                loseUI.Lose();
            }
        }
    }
    
}
