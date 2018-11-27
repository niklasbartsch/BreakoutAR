using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPositionScript : MonoBehaviour {
    public Transform target;

    public GameObject bricks;

    void Start()  {

    }

    void FixedUpdate()  {
        Vector3 positionInPlane = target.position;
        positionInPlane.z = bricks.transform.position.z;
        positionInPlane.y = bricks.transform.position.y;
        gameObject.transform.position = positionInPlane;
        print(positionInPlane.x + "  "+  positionInPlane.y + "  " + positionInPlane.z);
    }
}