using UnityEngine;
using System.Collections;

/// <summary>
/// controls many of the states in the game
/// <remarks>For use in all stages in this particular game</remarks>
/// </summary>
public class GameController : MonoBehaviour
{

    ScreenFader fader;
    PartnerMovement player;

    Color fadeFullColor;
    Color fadeNoneColor = Color.clear;
    float timer, timeLimit;

    public float fadeDuration = 1f;

    // Use this for initialization
    void Start()
    {
        fader = Camera.main.GetComponent<ScreenFader>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PartnerMovement>();
        fadeFullColor = Color.white;

        GameStart();
    }

    void GameStart()
    {
        //fade into the scene
        fadeFullColor = Color.white;
        fader.SetScreenOverlayColor(fadeFullColor);
        fader.StartFade(fadeNoneColor, fadeDuration);

        //set time, time limit
        timer = 0;
        timeLimit = 1f;
    }

    public void GameOver()
    {
        //fade out of the scene
        fadeFullColor = Color.red;
        fader.SetScreenOverlayColor(fadeNoneColor);
        fader.StartFade(fadeFullColor, fadeDuration);

        //disable player
        player.enabled = false;

        //delay load
        Invoke("ResetLevel", fadeDuration - 2);
    }

    /// <summary>
    /// <remarks>used in conjunction with Invoke function</remarks>
    /// </summary>
    void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LevelComplete()
    {
        //fade out of the scene
        fadeFullColor = Color.white;
        fader.SetScreenOverlayColor(fadeNoneColor);
        fader.StartFade(fadeFullColor, fadeDuration);

        //disable player
        player.enabled = false;

        //load next level
        Invoke("LoadNextLevel", fadeDuration - 2);
    }

    /// <summary>
    /// loads next level in build settings
    /// <remarks>used in conjunction with Invoke function</remarks>
    /// </summary>
    void LoadNextLevel() { 
        Application.LoadLevel(Application.loadedLevel + 1); 
    }
}