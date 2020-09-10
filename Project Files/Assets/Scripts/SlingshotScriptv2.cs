using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScriptv2 : MonoBehaviour
{
    GameObject Axis, Plank;
    Rigidbody2D AxisRB, PlankRB;
    public float defaultRotation;

    void Start()
    {
        Axis = GameObject.Find("Axis");
        AxisRB = Axis.GetComponent<Rigidbody2D>();
        Plank = GameObject.Find("Seg6");
        PlankRB = Plank.GetComponent<Rigidbody2D>();
        defaultRotation = PlankRB.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        SpinControl();
    }

    void SpinControl()
    {
        int spinSpeed = 600;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            //AxisRB.rotation += spinSpeed;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            
            AxisRB.rotation += spinSpeed;
        }
    }


}


