﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float detectionDistance = 5f;

    RaycastHit hit;
    Transform cam;

    GameObject previousObject;
    public LayerMask item;

    void Start()
    {
        cam = Camera.main.transform;
    }

    

    void Update()
    {

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, detectionDistance, item))
        {
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            if (hit.transform.gameObject != previousObject)
            {
                print("yip");
                if (previousObject != null)
                {
                    previousObject.GetComponent<Outline>().enabled = false;
                }

                previousObject = hit.transform.gameObject;
                hit.transform.GetComponent<Outline>().enabled = true;
            }


        }
        else
        {
            if (previousObject != null)
            {
                previousObject.GetComponent<Outline>().enabled = false;
                previousObject = null;
            }
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * detectionDistance, Color.green);
        }

    }
}
