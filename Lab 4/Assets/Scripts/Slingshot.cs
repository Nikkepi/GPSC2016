using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

    static public Slingshot S; 
    public float velocityMult = 6f;
    public GameObject prefabProjectile;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public GameObject launchPoint;
    void Awake()
    {
        Transform launchPointTrans =
        transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
        S = this;
    }

    void OnMouseEnter()
    {
        
        launchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }
    void OnMouseDown()
    {
        // The player has pressed the mouse utton while over Slinshot
        aimingMode = true;
        // Instantiate a projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Start it at the launch point
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        // If the Slingshot is not in aiming mode, don't run this script
        if (!aimingMode)
            return;
        // Get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        // Convert the mouse position to 3D world coordinates
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;
        // Limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        // Move the projectile to this new position
        
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        {
            // The mouse has been released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity =
             -mouseDelta * velocityMult;
            FollowCam.S.poi = projectile;
            projectile = null;
        }
    }


}


