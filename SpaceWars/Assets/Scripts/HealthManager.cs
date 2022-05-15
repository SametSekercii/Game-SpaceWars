using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    
    public float Health;
    float MaxHealth;
    public Text HealthText;
    public Image HealthBar;
    Transform PlayerCamera;
    public Transform HealthUI;
    Vector3 LookDirectionVector;
    bool IsDead;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
        IsDead = false;
        MaxHealth = Health;
        
    }


    void Update()
    {
        DeathCheck();
        if (IsDead)
        {
            Destroy(gameObject);   
        }
        LookDirectionVector = (HealthUI.position - PlayerCamera.position).normalized;
        Quaternion LookRotation=Quaternion.LookRotation(LookDirectionVector);
        HealthUI.rotation = LookRotation;
        
    }

    public void TakeDamage(int Damage)
    {
        StartCoroutine(TakeDamageSlowly(Damage));

    }
    IEnumerator TakeDamageSlowly(int Damage)
    {
        //Debug.Log("TakingDamage");
        for (int i = 0; i < Damage; i++)
        {
            Health--;
            HealthText.text = Health.ToString();
            HealthBar.fillAmount = Health / MaxHealth;
            
            yield return null;
        }


    }
    public void TakeDamageInstantly(int damage)
    {
        Health -= damage;
    }
    void DeathCheck()
    {
        if (Health <= 0)
        {
            IsDead = true;
        }

    }
}
