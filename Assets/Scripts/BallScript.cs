using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public Rigidbody rb;
    public bool inPlay;
    public Transform paddle;
    public float speed = 2500;
    public Transform explosion;
    public GameManager gm;
    public GameObject FieldImage;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!inPlay){
            transform.position = paddle.position;
        }
        if(Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            AddTheForce();
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bottom")){
            Debug.Log("The Ball hit the bottom of the Screen");
            inPlay = false;
            rb.velocity = Vector3.zero;

            gm.UpdateLives(-1);
        }

        
    }

    private void AddTheForce(){
        //gameObject.transform.rotation = FieldImage.transform.rotation;
        rb.AddForce(FieldImage.transform.forward * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Brick")){
            Transform newExplosion =  Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(collision.gameObject);
            gm.UpdateScore(10);
        }
    }
}
