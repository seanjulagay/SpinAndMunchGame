using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject PigPrefab, PandaPrefab, CatPrefab, BearPrefab, ProjectilePrefab;
    public bool projectileLaunched, canSpawn, characterPicking;
    int waitTime;

    GameObject Projectile;
    Transform ProjectilePosition, ProjectileGroup;
    FixedJoint2D RopeEnd;
    GameControllerScript gameControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = GameObject.Find("GameControllerScript").GetComponent<GameControllerScript>();

        ProjectileGroup = GameObject.Find("Projectile Group").GetComponent<Transform>();
        ProjectilePosition = GameObject.Find("ReloadPosition").GetComponent<Transform>();
        RopeEnd = GameObject.Find("Seg6").GetComponent<FixedJoint2D>();

        waitTime = 2;
        canSpawn = false;
        characterPicking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterPicking == true && gameControllerScript.gameStart == true)
        {
            CharacterPicker();
            
        } else if (characterPicking == false && gameControllerScript.gameStart == true)
        {
            EjectReloadProjectile();
        }
    }

    void CharacterPicker()
    {
        if (gameControllerScript.character == "Pig")
        {
            ProjectilePrefab = PigPrefab;
            print("Pig chosen");
        }
        else if (gameControllerScript.character == "Bear")
        {
            ProjectilePrefab = BearPrefab;
            print("Bear chosen");
        }
        else if (gameControllerScript.character == "Panda")
        {
            ProjectilePrefab = PandaPrefab;
            print("Panda chosen");
        }
        else if (gameControllerScript.character == "Cat")
        {
            ProjectilePrefab = CatPrefab;
            print("Cat chosen");
        }
        else
        {
            print("Error in selection!");
        }

        characterPicking = false;
    }

    void EjectReloadProjectile()
    {
        if (projectileLaunched == false && canSpawn == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Projectile launched");
                RopeEnd.enabled = false;
                projectileLaunched = true;
                StartCoroutine(canSpawnTimer());

            }
        } else if (projectileLaunched == true && canSpawn == true)
        {
            Projectile = Instantiate(ProjectilePrefab, ProjectilePosition.position,
                    ProjectilePosition.rotation);
            print("Projectile Instantiated");
            Projectile.transform.SetParent(ProjectileGroup);
            RopeEnd.enabled = true;
            RopeEnd.connectedBody = Projectile.GetComponent<Rigidbody2D>();
            projectileLaunched = false;
            canSpawn = false;
        }
    }

    IEnumerator canSpawnTimer()
    {
        yield return new WaitForSeconds(3);
        canSpawn = true;
    }

}
