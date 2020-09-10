using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    GameObject CatSelect, PigSelect, BearSelect, PandaSelect, GameStarter, ReplayButton;
    GameObject background, selectChar, Logo, Plank;
    Text scoreText, timeText, replayScoreText, scoreText2;
    ScoreScript scoreScript;       
    GameControllerScript gameControllerScript;
    ProjectileScriptv2 projectileScriptv2;
    SlingshotScriptv2 slingshotScriptv2;
    ObstaclesScript obstaclesScript;
    int scoreValue, timeInt;



    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText2 = GameObject.Find("ScoreText2").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        replayScoreText = GameObject.Find("ReplayButtonText").GetComponent<Text>();
        scoreScript = GameObject.Find("ScoreScript").GetComponent<ScoreScript>();
        gameControllerScript = GameObject.Find("GameControllerScript").GetComponent<GameControllerScript>();
        projectileScriptv2 = GameObject.Find("Projectile Group").GetComponent<ProjectileScriptv2>();
        slingshotScriptv2 = GameObject.Find("Slingshot Group").GetComponent<SlingshotScriptv2>();
        obstaclesScript = GameObject.Find("Obstacles Group").GetComponent<ObstaclesScript>();
        background = GameObject.Find("Background");
        selectChar = GameObject.Find("Selectcharacter");

        CatSelect = GameObject.Find("CatSelect");
        PigSelect = GameObject.Find("PigSelect");
        BearSelect = GameObject.Find("Bear");
        PandaSelect = GameObject.Find("Panda");
        GameStarter = GameObject.Find("StartButton");
        ReplayButton = GameObject.Find("ReplayButton");
        Logo = GameObject.Find("Logo");
        GameStarter.SetActive(false);
        ReplayButton.SetActive(false);
        scoreText2.enabled = false;

        Plank = GameObject.Find("Seg6");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateTimer();
        ReplayCheck();
        ConvertTimeToInt();
        ScoreText2Updater();
    }

    void ConvertTimeToInt()
    {
        timeInt = (int)gameControllerScript.timeLeft;
    }

    void UpdateScore()
    {
        scoreValue = scoreScript.score;
        scoreText.text = "Score: " + scoreValue;
    }

    void UpdateTimer()
    {
        timeText.text = "Time " + timeInt;
    }


    public void SelectPig()
    {
        gameControllerScript.character = "Pig";
        GameStarter.SetActive(true);
    }

    public void SelectCat()
    {
        gameControllerScript.character = "Cat";
        GameStarter.SetActive(true);
    }

    public void SelectBear()
    {
        gameControllerScript.character = "Bear";
        GameStarter.SetActive(true);
    }

    public void SelectPanda()
    {
        gameControllerScript.character = "Panda";
        GameStarter.SetActive(true);
    }

    public void GameStart()
    {
        gameControllerScript.gameStart = true;
        CatSelect.SetActive(false);
        PigSelect.SetActive(false);
        BearSelect.SetActive(false);
        PandaSelect.SetActive(false);
        background.SetActive(false);
        selectChar.SetActive(false);
        Logo.SetActive(false);
        scoreScript.score = 0;

        Plank.GetComponent<Rigidbody2D>().freezeRotation = false;    

        projectileScriptv2.launched = true;

        GameStarter.SetActive(false);
    }

    public void Replay()
    {
        CatSelect.SetActive(true);
        PigSelect.SetActive(true);
        BearSelect.SetActive(true);
        PandaSelect.SetActive(true);
        background.SetActive(true);
        selectChar.SetActive(true);
        Logo.SetActive(true);
        scoreText2.enabled = false;

        gameControllerScript.timeLeft = 60;
        ReplayButton.SetActive(false);

        Plank.GetComponent<Rigidbody2D>().rotation = 0f;
        Plank.GetComponent<Rigidbody2D>().freezeRotation = true;
        Plank.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        /*gameControllerScript.gameStart = true;
        gameControllerScript.timeLeft = 10;
        gameControllerScript
        ReplayButton.SetActive(false);
        */
    }

    public void ForceReset()
    {
        gameControllerScript.gameStart = false;
        gameControllerScript.ScriptController();
        gameControllerScript.timeLeft = 0;
    }

    public void ReplayCheck()
    {
        if (gameControllerScript.timeLeft <= 0)
        {
            ReplayButton.SetActive(true);
            background.SetActive(true);
            scoreText2.enabled = true;
        }
    }

    void ScoreText2Updater()
    {
        scoreText2.text = "You scored " + scoreScript.score + "!";
    }
}
