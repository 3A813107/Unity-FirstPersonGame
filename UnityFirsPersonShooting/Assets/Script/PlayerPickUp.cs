using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField]private float pickupRange;
    [SerializeField]private LayerMask pickupLayer;
    [SerializeField]private LayerMask Enemy;

    private Camera cam;
    private Inventory inventory;

    private EquipmentManager Manager;

    private PlayerHUD hud;
    

    private void Start()
    {
        cam=GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
        Manager=GetComponent<EquipmentManager>();
    }
    private void Update()
    {
        PickUpCheak();
        TargetCheak();
    }

    private void PickUpCheak()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2 ,Screen.height / 2));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,pickupRange,pickupLayer))
        {
            Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
            hud.UpdatePickUpUI("[E] 撿起 "+newItem.name);
            if(Input.GetKeyDown(KeyCode.E))
            {
                inventory.AddItem(newItem);
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            hud.UpdatePickUpUI("");
        }

    }
    private void TargetCheak()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2 ,Screen.height / 2));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,inventory.GetItem(Manager.currentEquippedWeapon).range,Enemy))
        {
            hud.TargetImfo.SetActive(true);
            EnemyImfo newEnemy=hit.transform.GetComponent<EnemyObject>().enemyImfo as EnemyImfo;
            EnemyStats newEnemyStats=hit.transform.GetComponent<EnemyStats>();
            hud.UpdateTargetImfo(newEnemy.Name,newEnemyStats.maxHealth,newEnemyStats.Health,0,0);
        }
        else
        {
            hud.TargetImfo.SetActive(false);
        }
    }
}
