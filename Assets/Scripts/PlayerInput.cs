﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {

    public static UnityAction<bool> onHasController = null;

    public static UnityAction onTriggerUp = null;
    public static UnityAction onTriggerDown = null;
    public static UnityAction onTouchpadUp = null;
    public static UnityAction onTouchpadDown = null;

    private bool hasController = false;
    private bool inputActive = true;

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerFound;
    }

    // Use this for initialization
    void Start() {

    }
    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerFound;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputActive) 
            return;

            hasController = CheckForController(hasController);

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (onTriggerDown != null)
                {
                    onTriggerDown();
                }
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (onTriggerUp != null)
                {
                    onTriggerUp();
                }
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
            {
                if (onTouchpadDown != null)
                {
                    onTouchpadDown();
                }
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
            {
                if (onTouchpadUp != null)
                {
                    onTouchpadUp();
                }
            }


    }
    private bool CheckForController(bool currentValue) {
        bool controllerCheck = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) ||
                                OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);

        if (currentValue == controllerCheck)
        {
            return currentValue;
        }
        if (onHasController != null) {
            onHasController(controllerCheck);
        }
        return controllerCheck;
    }
    private void PlayerFound() {
        inputActive = true;
    }
    private void PlayerLost() {
        inputActive = false;
    }
}
