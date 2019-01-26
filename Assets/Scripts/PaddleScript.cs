using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    public GameObject left;
    public GameObject right;
    public float speed = 1.0f;
    public float rightScreenEdge = 30.0f;
    public float leftScreenEdge = -30.0f;
    public GameObject paddleImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed); // Time.DeltaTime - Timebased movement

        transform.position = new Vector3(paddleImage.transform.position.x, transform.position.y, transform.position.z);


        /*
         * 
         * if (transform.position.x < left.transform.position.x)
        {
            transform.position = new Vector3(left.transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > right.transform.position.x)
        {
            transform.position = new Vector3(right.transform.position.x, transform.position.y, transform.position.z);
        }



      
        if(transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector3(leftScreenEdge, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector3(rightScreenEdge, transform.position.y, transform.position.z);
        }
        */
    }
}
