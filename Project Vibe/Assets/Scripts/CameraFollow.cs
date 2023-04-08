using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f; //offset of camera on y axis (moves the camera a fixed amount up or down)
    public float zOffset = -5f;
    public Transform target; //choose which object to follow, in this case our player



    // Update is called once per frame

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset, zOffset);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}