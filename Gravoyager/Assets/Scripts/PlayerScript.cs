﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
  

    public float RotateSpeed = 80f;
    public float MovementSpeed = 20f;

    public float boostCooldown = 1;

    private Rigidbody2D rigidbody;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))

            rigidbody = this.GetComponent.<Rigidbody2D>();

            rigidbody.AddForce(transform.up * MovementSpeed);



    }

  

}


   
   
      