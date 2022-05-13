using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPointController : MonoBehaviour
{

    public Transform[] RedAsteroids;
    public Transform BlueAsteroid;
    
    public Transform[] WayPoints;
    public Vector3[] WayPointsPos;
    


    private void Awake()
    {
        WayPointsPos = new Vector3[WayPoints.Length];
        for(int i = 0; i < WayPoints.Length; i++)
        {
            WayPointsPos[i]=WayPoints[i].position;
            
        }
    }
    public int WayPointsLength { get { return WayPointsPos.Length; } }

    void Update()
    {
        BlueAsteroid.Rotate(new Vector3(1 * Time.deltaTime * 60f, 0, 1 * Time.deltaTime * 75f));
        for (int i = 0; i < RedAsteroids.Length; i++)
        {

            RedAsteroids[i].Rotate(new Vector3(1 * Time.deltaTime * 240f, 0, 1 * Time.deltaTime * 240f));
        }
        
    }
    public Vector3 GetWayPoint(int index)
    {
        return WayPointsPos[index];

    }


}
