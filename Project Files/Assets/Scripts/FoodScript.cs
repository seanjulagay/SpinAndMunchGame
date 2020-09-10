using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{

    ScoreScript scoreScript;
    PolygonCollider2D ThisCollider;
    SpriteRenderer ThisSprite;

    public AudioSource MunchSound;

    void Start()
    {
        scoreScript = GameObject.Find("ScoreScript").GetComponent<ScoreScript>();
        ThisCollider = GetComponent<PolygonCollider2D>();
        ThisSprite = GetComponent<SpriteRenderer>();
        MunchSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MunchSound.Play();
        scoreScript.score++;
        ThisCollider.enabled = false;
        ThisSprite.enabled = false;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(7);
        ThisCollider.enabled = true;
        ThisSprite.enabled = true;
    }
}
