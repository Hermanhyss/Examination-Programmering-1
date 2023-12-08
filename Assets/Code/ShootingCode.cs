using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingCode : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
   
    void Start()
    {
        
    }

    void Update()
    {
       if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation); 
        }
    }
}
