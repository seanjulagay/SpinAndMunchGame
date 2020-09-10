using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour
{
    /*public Rigidbody2D ProjectilePrefab;
    GameObject Axis, Projectile, ReloadPosition, RopeEnd;
    Rigidbody2D AxisRigidbody, ProjectileRigidbody, ProjectileInstance;
    Transform ProjectileTransform, ReloadPositionTransform;
    FixedJoint2D RopeEndJoint;
    bool canSpinAxis, projectileEjected;
    GameStarterScript gameStarterScript;

    void Start()
    {
        gameStarterScript = GameObject.Find("GameStarterScript").GetComponent<GameStarterScript>();

        InitialInstantiation();

        Axis = GameObject.Find("Axis");
        AxisRigidbody = Axis.GetComponent<Rigidbody2D>();

        Projectile = GameObject.FindWithTag("Pig");
        ProjectileTransform = Projectile.GetComponent<Transform>();
        ProjectileRigidbody = Projectile.GetComponent<Rigidbody2D>();

        ReloadPosition = GameObject.Find("ReloadPosition");
            ReloadPositionTransform = ReloadPosition.GetComponent<Transform>();

        RopeEnd = GameObject.Find("Seg6");
            RopeEndJoint = RopeEnd.GetComponent<FixedJoint2D>();

        canSpinAxis = true;
        projectileEjected = false;
    }

    void Update()
    {
        /*if (gameStarterScript.gameStart == true)
        {
            if (canSpinAxis == true)
            {
                MoveAxis();
            }


            Eject();
            Reload();
            AxisLimiter();

        }

        if (canSpinAxis == true)
        {
            MoveAxis();
        }


        Eject();
        Reload();
        AxisLimiter();
    }

    void MoveAxis()
    {
        float force = 8f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AxisRigidbody.rotation -= force;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            AxisRigidbody.rotation += force;
        }
        
    }

    void Eject()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RopeEndJoint.GetComponent<FixedJoint2D>().enabled = false;
            projectileEjected = true;
        }
    }

    void AxisLimiter()
    {
        if (AxisRigidbody.rotation >= 110)
        {
            canSpinAxis = false;
            AxisRigidbody.rotation = 110;
        }
        else
        {
            canSpinAxis = true;
        }

        if (AxisRigidbody.rotation <= -110)
        {
            canSpinAxis = false;
            AxisRigidbody.rotation = -110;
        }
        else
        {
            canSpinAxis = true;
        }
    }

    void Reload()
    {
        if(projectileEjected == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ProjectileInstance = Instantiate(ProjectilePrefab, ReloadPositionTransform.position,
                    ReloadPositionTransform.rotation) as Rigidbody2D;
                RopeEndJoint.enabled = true;
                RopeEndJoint.connectedBody = ProjectileInstance.GetComponent<Rigidbody2D>();
                projectileEjected = false;
            }
        }
    }

    void InitialInstantiation()
    {
        gameStarterScript = GameObject.Find("GameStarterScript").GetComponent<GameStarterScript>();
        RopeEndJoint.enabled = true;
        RopeEndJoint.connectedBody = ProjectileInstance.GetComponent<Rigidbody2D>();
    }
    
*/

}
