using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject grenade;

    public float throwFoece = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Launch();
        }
    }

    private void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade,spawnPoint.position,spawnPoint.rotation);
        Rigidbody rb=grenadeInstance.GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.forward * throwFoece,ForceMode.VelocityChange);

    }
}
