using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
  

    public float RotateSpeed = 80f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
    }

  

}


   
   
      