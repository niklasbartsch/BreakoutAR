using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class BallScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private Rigidbody rb;
    public bool inPlay;
    public Transform paddle;
    public float speed = 2500;
    public Transform explosion;
    public GameManager gm;
    public GameObject FieldImage;
    private int number = 0;
    private bool goValue = false;
    public GameObject bricks;
    public TextMesh countdownText;
    public bool isTracked = false;
    private bool isStarted = false; //


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }

    // Update is called once per frame
    void Update () {

        if (!inPlay)
        {
            transform.position = paddle.position;
            //transform.position = new Vector3(transform.position.x, transform.position.y, bricks.transform.position.z);

        }

        if (!isStarted && Input.GetButton("Tap"))
        {
            isStarted = true;
            goValue = true;

            
        }
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, bricks.transform.position.z);



        //Input.GetButtonDown("Jump"    eingabe von Leertaste
        //var touch = Input.GetTouch();
        // OVRInput.Get(OVRInput.Touch.PrimaryTouchpad
        if (goValue == true && !inPlay)
        {
            inPlay = true;
            AddTheForce();
            goValue = false;
        }


        if (number >= 400)
        {
            goValue = true;
            number = 0;
        }


        if (gm.lives <= 0)
        {
            number = 0;
            inPlay = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bottom")){
            Debug.Log("The Ball hit the bottom of the Screen");
            inPlay = false;
            rb.velocity = Vector3.zero;

            gm.UpdateLives(-1);
            number = 0;
            goValue = false;
            isStarted = false;
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
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            inPlay = false;
            transform.position = paddle.position;
            //transform.position.z. = bricks.transform.position.z;
            //transform.position = new Vector3(transform.position.x, transform.position.y, bricks.transform.position.z);

            rb.velocity = Vector3.zero;

            gm.UpdateLives(-1);
            number = 0;
            goValue = false;
        }
    }
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            isTracked = true;
        }
        else
        {
            isTracked = false;
        }

    }
}
