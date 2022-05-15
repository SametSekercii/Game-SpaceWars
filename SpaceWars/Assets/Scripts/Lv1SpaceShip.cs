using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1SpaceShip : SpaceShips
{
   Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    float elapsedtime;
    float delay = 1f / 5f;
    int LaserSpeed=250;



    private void Start()
    {
        moveSpeed = 75f;
        RotationSpeed = 120f;
    }
    private void Update()
    {
        Move();
        if (Input.GetMouseButton(0))
        {
            if((elapsedtime+=Time.deltaTime) > delay)
            {
                Fire();
                elapsedtime=0;
            }
             
        }
    }
    protected override void Fire()
    {
        var laser=Lv1LaserPooler.Instance.getLasersFromPool1();

        if (laser != null)
        {
            
         laser.transform.position = Guns[0].transform.position;
         laser.transform.rotation = Guns[0].transform.rotation;
         laser.SetActive(true);
         laser.GetComponent<Rigidbody>().velocity = LaserSpeed * Guns[0].up;
            
        }
        var laser2 = Lv1LaserPooler.Instance.getLasersFromPool2();
        if (laser2 != null)
        {

            laser2.transform.position = Guns[1].transform.position;
            laser2.transform.rotation = Guns[1].transform.rotation;
            laser2.SetActive(true);
            laser2.GetComponent<Rigidbody>().velocity = LaserSpeed * Guns[1].up;

        }


    }

    protected override void Move()
    {
        float VerticalmoveAxis = Input.GetAxisRaw("Vertical");
        float HorizontalAxis = Input.GetAxisRaw("Horizontal");
        float HighAxis = Input.GetAxisRaw("High");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            transform.position += transform.right * HorizontalAxis * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            transform.position += transform.forward * VerticalmoveAxis * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
            transform.position += transform.up * HighAxis * Time.deltaTime * moveSpeed;















    }
}
