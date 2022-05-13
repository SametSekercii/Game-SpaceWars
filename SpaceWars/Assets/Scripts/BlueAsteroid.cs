using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAsteroid : MonoBehaviour
{
    private PlayerSpawnPointController Instance;
    Vector3 TargetPosition;
    private int index = 0;
    private float moveSpeed = 10f;
    
    void Start()
    {
       Instance=FindObjectOfType<PlayerSpawnPointController>();
       TargetPosition=Instance.GetWayPoint(index);
    }

   
    void Update()
    {
        float distance=Vector3.Distance(TargetPosition,transform.position);
        if (distance < 0.2f)
        {
            SetNewPosition();
        }
        GoToTarget();
        
    }
    void GoToTarget()
    {
        float distance=Vector3.Distance(TargetPosition,transform.position);
        if (distance < 0.2f) return;
        Vector3 DirectionV=(TargetPosition - transform.position).normalized;
        transform.position+=DirectionV*moveSpeed*Time.deltaTime;
    }
    void SetNewPosition()
    {
        if (index + 1 == Instance.WayPointsLength)
        {
            index = 0;
            TargetPosition=Instance.GetWayPoint(index);
            return;
        }
        index++;
        TargetPosition=Instance.GetWayPoint(index); 

    }
}
