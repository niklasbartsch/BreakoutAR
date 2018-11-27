using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowText : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    private bool isTracked = false;
    public Canvas myCanvas;



    // Use this for initialization
    void Start()
    {
        myCanvas.gameObject.active = false;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTracked)
        {
            myCanvas.gameObject.active = true;
        }
        else{
            myCanvas.gameObject.active = false; 
        }


    }

    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            isTracked = true;

        }

        else if (newStatus == TrackableBehaviour.Status.NOT_FOUND &&
                    previousStatus == TrackableBehaviour.Status.TRACKED)
        {
            isTracked = false;

     
        }
    }


}
