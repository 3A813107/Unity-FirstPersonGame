using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField]private float pickupRange;
    [SerializeField]private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;

    private PlayerHUD hud;
    

    private void Start()
    {
        cam=GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
    }
    private void Update()
    {
        PickUpCheak();
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
}
