using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject grenade;
    [SerializeField]private PlayerHUD hud;
    [SerializeField]private Inventory inventory;

    public float throwFoece = 10f;
    // Start is called before the first frame update
    void Start()
    {
        inventory=GetComponent<Inventory>();
        hud=GetComponent<PlayerHUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !GameManager.isPause && !GameManager.instance.PlayerDie)
        {
            if(inventory.grenadeNum>0)
                Launch();
        }
    }

    private void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade,spawnPoint.position,spawnPoint.rotation);
        Rigidbody rb=grenadeInstance.GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.forward * throwFoece,ForceMode.VelocityChange);
        inventory.grenadeNum--;
        hud.UpdateGrenadeUI(inventory.grenadeNum);
    }
}
