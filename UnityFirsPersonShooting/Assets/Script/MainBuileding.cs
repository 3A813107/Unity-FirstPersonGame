using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


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

    public float explosionForce = 10f;
    public float radius = 20f;
    public GameObject explosionEffect;
    public AudioSource aud;
    public AudioClip sound;

    
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            EnemyController_shoot enemy = collider.GetComponent<EnemyController_shoot>();
            if(enemy.HaveBoom)
            {
                StartCoroutine(EndingExplode());
                loseUI.Lose();
            }
        }
    }

        private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        
        CameraShaker.Instance.ShakeOnce(4f,4f,0.5f,1f);

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            EnemyStats enemy = near.GetComponent<EnemyStats>();

            if(rig!=null)
            {
                rig.AddExplosionForce(explosionForce,transform.position,radius,1f,ForceMode.Impulse);
            }
            if(enemy!=null)
            {
                enemy.DamageCheak(100);
            }
        }
        Instantiate(explosionEffect,transform.position,transform.rotation);
        aud.PlayOneShot(sound,0.2f);
    }

    IEnumerator EndingExplode()
    {
        Explode();
        yield return new WaitForSeconds(0.4f);
        Explode();
        yield return new WaitForSeconds(0.5f);
        Explode();
        yield return new WaitForSeconds(0.3f);
        Explode();
        yield return new WaitForSeconds(1f);
        Explode();
    }
    
}
