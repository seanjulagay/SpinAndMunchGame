using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControlScript : MonoBehaviour
{

    public Sprite PigSitting, PigFlying, PigOpen, PigMunching;
    public Sprite CatSitting, CatFlying, CatOpen, CatMunching;
    public Sprite BearSitting, BearFlying, BearOpen, BearMunching;
    public Sprite PandaSitting, PandaFlying, PandaOpen, PandaMunching;
    Sprite ProjectileSitting, ProjectileFlying, ProjectileOpen, ProjectileMunching;
    GameObject Projectile;
    Rigidbody2D ProjectileRigidbody;
    Sprite ProjectileSprite;
    GameControllerScript gameControllerScript;

    public bool isFlying, hitGround;

    // Start is called before the first frame update
    void Start()
    {
        ProjectileRigidbody = transform.GetComponent<Rigidbody2D>();
        gameControllerScript = GameObject.Find("GameControllerScript").GetComponent<GameControllerScript>();
        isFlying = false;
        hitGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying == false && hitGround == false)
        {
            if (ProjectileRigidbody.velocity.x >= 1)
            {
                transform.GetComponent<SpriteRenderer>().sprite = ProjectileFlying;
                transform.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
            else if (ProjectileRigidbody.velocity.x < 1)
            {
                transform.GetComponent<SpriteRenderer>().sprite = ProjectileSitting;
                transform.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
        }
        else if (isFlying == true && hitGround == false)
        {
            transform.GetComponent<SpriteRenderer>().sprite = ProjectileOpen;
            transform.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }

        SelectCharacter();
    }

    void SelectCharacter()
    {
        if (gameControllerScript.character == "Pig")
        {
            ProjectileSitting = PigSitting;
            ProjectileFlying = PigFlying;
            ProjectileOpen = PigOpen;
            ProjectileMunching = PigMunching;
        }
        else if (gameControllerScript.character == "Cat")
        {
            ProjectileSitting = CatSitting;
            ProjectileFlying = CatFlying;
            ProjectileOpen = CatOpen;
            ProjectileMunching = CatMunching;
        }
        else if (gameControllerScript.character == "Bear")
        {
            ProjectileSitting = BearSitting;
            ProjectileFlying = BearFlying;
            ProjectileOpen = BearOpen;
            ProjectileMunching = BearMunching;
        }
        else if (gameControllerScript.character == "Panda")
        {
            ProjectileSitting = PandaSitting;
            ProjectileFlying = PandaFlying;
            ProjectileOpen = PandaOpen;
            ProjectileMunching = PandaMunching;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            print("Hit the ground!");
            transform.GetComponent<SpriteRenderer>().sprite = ProjectileMunching;
            transform.GetComponent<SpriteRenderer>().sortingOrder = 5;
            hitGround = true;
        }
    }
}
