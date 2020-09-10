using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{

    Vector3 cloud1PosA, cloud1PosB, cloud2PosA, cloud2PosB, nextPos1, nextPos2;
    Transform Cloud1, Cloud2;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        cloud1PosA = GameObject.Find("Cloud1PosA").GetComponent<Transform>().position;
        cloud1PosB = GameObject.Find("Cloud1PosB").GetComponent<Transform>().position;
        cloud2PosA = GameObject.Find("Cloud2PosA").GetComponent<Transform>().position;
        cloud2PosB = GameObject.Find("Cloud2PosB").GetComponent<Transform>().position;
        Cloud1 = GameObject.Find("Cloud1").GetComponent<Transform>();
        Cloud2 = GameObject.Find("Cloud2").GetComponent<Transform>();
        speed = .02f;
        nextPos1 = cloud1PosA;
        nextPos2 = cloud2PosB;
    }

    // Update is called once per frame
    void Update()
    {
        Cloud1Movement();
        Cloud2Movement();
    }

    void Cloud1Movement()
    {
        if(Cloud1.position == cloud1PosA)
        {
            nextPos1 = cloud1PosB;
        }
        else if(Cloud1.position == cloud1PosB)
        {
            nextPos1 = cloud1PosA;
        }

        Cloud1.position = Vector3.MoveTowards(Cloud1.position, nextPos1, speed);
    }

    void Cloud2Movement()
    {
        if (Cloud2.position == cloud2PosA)
        {
            nextPos2 = cloud2PosB;
        }
        else if (Cloud2.position == cloud2PosB)
        {
            nextPos2 = cloud2PosA;
        }

        Cloud2.position = Vector3.MoveTowards(Cloud2.position, nextPos2, speed);
    }
}
