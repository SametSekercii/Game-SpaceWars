using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    HealthManager CollisionHealth=new HealthManager();
    int damage = 25;
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        CollisionHealth = collision.gameObject.GetComponent<HealthManager>();
        if (CollisionHealth != null)
        {
            CollisionHealth.TakeDamage(damage);
            
        }
    }
}
