using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
    public Camera parallaxCamera;
    public float parallaxAmount;

    private Vector3 previousPosition;


    // Start is called before the first frame update
    void Start()
    {
        previousPosition = parallaxCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //compute how much the camera moved this frame
        Vector3 diff = parallaxCamera.transform.position - previousPosition;
        //move this object by that same amount scaled by parallaxAmount
        this.transform.position += diff * parallaxAmount;
        //reset the previousPosition to where the camera is this frame
        previousPosition = parallaxCamera.transform.position;
    }
}
