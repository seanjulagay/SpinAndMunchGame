using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprightScript : MonoBehaviour
{
    SpriteControlScript spriteControlScript;

    // Start is called before the first frame update
    void Start()
    {
        spriteControlScript = GameObject.Find("SpriteControlScript").GetComponent<SpriteControlScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collisionRigidbody = collision.transform.GetComponent<Rigidbody2D>();

        if (collision.transform.tag == "Projectile")
        {
            collisionRigidbody.rotation = 0f;
            collisionRigidbody.freezeRotation = true;


        }
   }
}
