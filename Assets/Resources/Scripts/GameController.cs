using UnityEngine;
using System.Collections;

/// <summary>
/// activation for all major events scenarios
/// <remarks>acts as catch-all class for triggering events during gameplay
/// work in conjunction with GameEventManager</remarks>
/// </summary>
public class GameController : MonoBehaviour
{

    public PartnerMovement player;

    // Use this for initialization
    void Awake()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        GameEventManager.TriggerGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.speed <= 0 || player.travelDistance <= 0)
            GameEventManager.TriggerGameOver();
    }


    #region Event Functions
    void GameStart()
    {

    }

    void GameOver()
    {

    }
    #endregion
}