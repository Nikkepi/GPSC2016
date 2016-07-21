using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    static public FollowCam S;
    public float easing = 0.05f;
    public Vector2 minXY;
    // The point of interest
    public GameObject poi;
    // The desired Z pos of the camera
    public float camZ;
    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {
        Vector3 destination;
        // don't do anything if there is no poi
        if (poi == null)
        {
            destination = Vector3.zero;

        }else
        {
            destination = poi.transform.position;
            //If poi is a projectile, chack to see if it's at rest
            if(poi.tag == "Projectile")
            {

                if(poi.GetComponent<Rigidbody>().IsSleeping())
                {

                    poi = null;
                    return;
                }
            }
            
        }
            
        // Get the position of the poi

        
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Retain a destination.z of CamZ
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }


}
