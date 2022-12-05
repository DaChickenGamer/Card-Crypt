using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float rotationSpeed;
    public float visionDistance;
    public LineRenderer lineOfSight;
    // Update is called once per frame
    void Update()
    {

        lineOfSight.SetPosition(0, transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);      //Looks for player
        if (hitInfo.collider != null)
        {
            Debug.DrawRay(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point); 
            lineOfSight.startColor = Color.red;
            lineOfSight.endColor = Color.red;
            if (hitInfo.collider.tag == "Player")
            {
                //Move torwards player
            }
            else
            {
                //Nothing
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.position + transform.right * visionDistance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.position + transform.right * visionDistance);
            lineOfSight.startColor = Color.green;
            lineOfSight.endColor = Color.green;
        }
    }
}
