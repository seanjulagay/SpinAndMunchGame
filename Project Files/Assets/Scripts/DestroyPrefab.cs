using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{

    ProjectileScriptv2 projectileScriptv2;
    GameControllerScript gameControllerScript;
    float destroyTime;
    SpriteControlScript spriteControlScript;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 5f;
        projectileScriptv2 = GameObject.Find("Projectile Group").GetComponent<ProjectileScriptv2>();
        gameControllerScript = GameObject.Find("GameControllerScript").GetComponent<GameControllerScript>();
        spriteControlScript = GetComponent<SpriteControlScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerScript.gameStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spriteControlScript.isFlying = true;
            }
         
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteControlScript.isFlying == true)
        {
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
