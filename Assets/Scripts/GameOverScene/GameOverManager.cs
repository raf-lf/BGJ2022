using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOverManager
{
    private static string gameOverCondition;

    public static void SetGameOverCondition(string gOType)
    {
        gameOverCondition = gOType;
    }

    public static string Condition
    {
        get { return gameOverCondition; }
    }
}