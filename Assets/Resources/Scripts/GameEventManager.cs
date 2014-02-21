using UnityEngine;
using System.Collections;

/// <summary>
/// handles all game events in game
/// Remember: delegates, events allow programmers to define what happens
/// in different scripts using similarly-named functions
/// <remarks>@Usage: not placed on game objects</remarks>
/// </summary>
public class GameEventManager
{
    public delegate void GameEvent();

    public static event GameEvent GameStart, GameOver;

    public static void TriggerGameStart()
    {
        if (GameStart != null)
        {
            GameStart();
        }
    }

    public static void TriggerGameOver()
    {
        if (GameOver != null)
        {
            GameOver();
        }
    }
}