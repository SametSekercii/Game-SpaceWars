using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShips : MonoBehaviour
{
    protected float moveSpeed;
    protected float RotationSpeed;
    public Transform[] Guns;
    

    protected int damage;
    protected int Health;

    protected abstract void Move();
    
    protected abstract void Fire();

    





}
