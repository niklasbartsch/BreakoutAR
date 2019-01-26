using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPositionScript : MonoBehaviour {
    public Transform target;        //paddle Image

    public GameObject bricks;

    void Start()  {

    }

    void Update()  {
        /*
        Vector3 positionInPlane = target.position;
        positionInPlane.z = bricks.transform.position.z;
        positionInPlane.y = bricks.transform.position.y;
        positionInPlane.x = target.position.x;

        gameObject.transform.position = positionInPlane;
         
   */



       

        //print(positionInPlane.x + "  "+  positionInPlane.y + "  " + positionInPlane.z);
    }
}