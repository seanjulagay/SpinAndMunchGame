using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public string character;
    public bool gameStart, replay;
    public float timeLeft;

    ProjectileScriptv2 projectileScriptv2;
    ObstaclesScript obstaclesScript;
    SlingshotScriptv2 slingshotScriptv2;
    ScoreScript scoreScript;

    
    
    // Start is called before the first frame update
    void Start()
    {
        projectileScriptv2 = GameObject.Find("Projectile Group").GetComponent<ProjectileScriptv2>();
        obstaclesScript = GameObject.Find("Obstacles Group").GetComponent<ObstaclesScript>();
        slingshotScriptv2 = GameObject.Find("Slingshot Group").GetComponent<SlingshotScriptv2>();
        scoreScript = GameObject.Find("ScoreScript").GetComponent<ScoreScript>();

        character = "Cat";
        gameStart = false;
        replay = false;

        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        ScriptController();
        TimerControl();
        
    }

    void TimerControl()
    {
        if (gameStart == true)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                gameStart = false;
                replay = true;
            }
        }
    }

    public void ScriptController()
    {
        if(gameStart == false)
        {
            projectileScriptv2.enabled = false;
            obstaclesScript.enabled = false;
            slingshotScriptv2.enabled = false;
        } else if (gameStart == true)
        {
            projectileScriptv2.enabled = true;
            obstaclesScript.enabled = true;
            slingshotScriptv2.enabled = true;
        }
    }
}
