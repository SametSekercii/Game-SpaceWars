using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    int damage = 999999;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Laser"))
           other.gameObject.SetActive(false);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        HealthManager collisionHealth = collision.gameObject.GetComponent<HealthManager>();
        if (collisionHealth != null)
            collisionHealth.TakeDamageInstantly(damage);

    }
}
