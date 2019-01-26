using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowText : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    private bool isTracked = false;
    public Canvas myCanvas;
    public GameManager gm;



    // Use this for initialization
    void Start()
    {
        myCanvas.gameObject.SetActive(false);
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
            myCanvas.gameObject.SetActive(true);
        }
        else{
            myCanvas.gameObject.SetActive(false); 
        }
        gm.isTracked = isTracked;

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
