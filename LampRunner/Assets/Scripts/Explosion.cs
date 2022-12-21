using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{

    public float expForce, radius;

    bool explosionOccur = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


        MakeColliderBigger();

    }



    void ExplosionFunc()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }

    void MakeColliderBigger()
    {
        rb.useGravity = false;
        GetComponent<BoxCollider>().isTrigger = true;
      
            ExplosionFunc();
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
    

        

    }
}
