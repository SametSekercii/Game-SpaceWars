using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShips1 : SpaceShips
{

    public Transform[] WayPoints;
    Vector3[] WayPointsPos;
    Vector3 TargetPatrolPosition;
    int index = 0;
    float elapsedTime;
    
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
            
    }

    protected override void Fire()
    {

        
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
        Vector3 DirectionV=(Player[0].transform.position-transform.position).normalized;
        Quaternion Look_Rotation =Quaternion.LookRotation(DirectionV);
        transform.rotation=Quaternion.Lerp(transform.rotation, Look_Rotation, Time.deltaTime*10f);

    }

    
}
