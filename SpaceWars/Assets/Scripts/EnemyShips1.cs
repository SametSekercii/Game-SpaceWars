using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShips1 : SpaceShips
{

    public Transform[] WayPoints;
    Vector3[] WayPointsPos;
    Vector3 TargetPatrolPosition;
    
    float elapsedTime;
    private float FireRate=1f/5f;
    float FireRateTimer;


    void Awake()
    {
        WayPointsPos = new Vector3[WayPoints.Length];
        moveSpeed = 25f;
        RotationSpeed = 240f;
        for(int i = 0; i < WayPoints.Length; i++)
        {
            WayPointsPos[i] =WayPoints[i].position; 
        }   
    }
    private int WayPointsLenght { get { return WayPoints.Length; } }


    void Update()
    {
        if ((elapsedTime += Time.deltaTime) > 2f)
        {
            int Rand = Random.Range(0, WayPointsLenght);
            setNewPatrolPosition(Rand);
            
            elapsedTime = 0;
        }
        Move();
        SetLookRotation();
        if ((FireRateTimer += Time.deltaTime) > FireRate)
        {
            Fire();
            FireRateTimer = 0;
        }


    }

    protected override void Fire()
    {
        var EnemyLaser1 = Lv1LaserPooler.Instance.getLasersFromPool1();
        var EnemyLaser2 = Lv1LaserPooler.Instance.getLasersFromPool2();

        if (EnemyLaser1 != null)
        {
            EnemyLaser1.transform.position = Guns[0].position;
            EnemyLaser1.transform.rotation = Guns[0].rotation;
            EnemyLaser1.SetActive(true);
            EnemyLaser1.GetComponent<Rigidbody>().velocity = 150 * Guns[0].up;
        }
        if (EnemyLaser2 != null)
        {
            EnemyLaser2.transform.position = Guns[1].position;
            EnemyLaser2.transform.rotation = Guns[1].rotation;
            EnemyLaser2.SetActive(true);
            EnemyLaser2.GetComponent<Rigidbody>().velocity = 150 * Guns[1].up;
        }
        

    }

    protected override void Move()
    {
        GoToTarget();
        
    }
    void setNewPatrolPosition(int rand)
    {
        
        TargetPatrolPosition=WayPointsPos[rand];
    }
    void GoToTarget()
    {
        
        Vector3 DirectionV=(TargetPatrolPosition-transform.position).normalized;
        transform.position+=DirectionV*moveSpeed*Time.deltaTime;
    }
    void SetLookRotation()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
        if (Player.Length == 0) return;
        Vector3 DirectionV=(Player[0].transform.position-transform.position).normalized;
        Quaternion Look_Rotation =Quaternion.LookRotation(DirectionV);
        transform.rotation=Quaternion.Lerp(transform.rotation, Look_Rotation, Time.deltaTime*10f);

    }

    
}
