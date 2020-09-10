using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScriptv2 : MonoBehaviour
{
    public GameObject PigPrefab, CatPrefab, BearPrefab, PandaPrefab;
    public GameObject Projectile;
    GameObject ProjectilePrefab, RopeEnd;
    Transform ProjectilePosition;
    GameControllerScript gameControllerScript;
    FixedJoint2D RopeEndJoint;

    public AudioSource FlyingSound;

    public bool launched, coroutineTrigger, ejected;

    // Start is called before the first frame update
    void Start()
    {
        ProjectilePosition = GameObject.Find("ReloadPosition").GetComponent<Transform>();
        RopeEnd = GameObject.Find("Seg6");
        RopeEndJoint = RopeEnd.GetComponent<FixedJoint2D>();
        gameControllerScript = GameObject.Find("GameControllerScript").GetComponent<GameControllerScript>();

        launched = true;
        coroutineTrigger = true;
        ejected = false;
        FlyingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerScript.gameStart == true)
        {
            PrefabSelect();
            EjectReload();
        }
    }

    void EjectReload()
    {
        if (launched == true)
        {
            Projectile = Instantiate(ProjectilePrefab, ProjectilePosition.position, ProjectilePosition.rotation);
            RopeEndJoint.enabled = true;
            RopeEnd.GetComponent<FixedJoint2D>().connectedBody = Projectile.GetComponent<Rigidbody2D>();
            ejected = false;
            launched = false;
            coroutineTrigger = true;
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RopeEndJoint.enabled = false;
                if (ejected == false)
                {
                    if (Projectile.GetComponent<Rigidbody2D>().velocity.x > 0)
                    {
                        Projectile.GetComponent<Rigidbody2D>().AddForce(transform.right *
                            (Projectile.GetComponent<Rigidbody2D>().velocity.x * 20));
                    }

                    if (Projectile.GetComponent<Rigidbody2D>().velocity.y > 0)
                    {
                        Projectile.GetComponent<Rigidbody2D>().AddForce(transform.up *
                            (Projectile.GetComponent<Rigidbody2D>().velocity.y * 20));
                    }
                    ejected = true;

                    FlyingSound.Play();
                }
                if (coroutineTrigger == true)
                {
                    StartCoroutine(AutoReload());
                }
            }
        }
    }

    void PrefabSelect()
    {
        if (gameControllerScript.gameStart == true)
        { 
            if (gameControllerScript.character == "Cat")
            {
                ProjectilePrefab = CatPrefab;
            }
            else if (gameControllerScript.character == "Pig")
            {
                ProjectilePrefab = PigPrefab;
            }
            else if (gameControllerScript.character == "Bear")
            {
                ProjectilePrefab = BearPrefab;
            }
            else if (gameControllerScript.character == "Panda")
            {
                ProjectilePrefab = PandaPrefab;
            }
        }
    }

    IEnumerator AutoReload()
    {
        coroutineTrigger = false;
        yield return new WaitForSeconds(1.5f);
        launched = true;
    }
}
