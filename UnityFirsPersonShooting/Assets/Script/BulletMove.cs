using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 hitPoint;
    private float timer;
    
    public int speed;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint-this.transform.position).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 1f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer+=Time.deltaTime;
        }
    }

    void OnCollosionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("123");
            Destroy(this.gameObject);
        }
    }

}
