using System;

/// <summary>
/// GameRules class to define and manage the rules and win conditions of the game.
/// </summary>
public static class GameRules
{
    /// <summary>
    /// Checks if the monster has met its win condition.
    /// </summary>
    /// <param name="monster">The monster player.</param>
    /// <returns>True if the monster meets its win condition, otherwise false.</returns>
    public static bool CheckMonsterWinCondition(MonsterClass monster)
    {
        // Monster wins if all hunters are defeated
        foreach (var player in MainGameLoop.Players)
        {
            if (player is HunterClass hunter && hunter.IsAlive)
            {
                return false;
            }
        }
        Logger.Log("Monster has won the game!");
        return true;
    }

    /// <summary>
    /// Checks if the hunters have met their win condition.
    /// </summary>
    /// <param name="monster">The monster player.</param>
    /// <returns>True if the hunters meet their win condition, otherwise false.</returns>
    public static bool CheckHunterWinCondition(MonsterClass monster)
    {
        // Hunters win if the monster is defeated
        if (!monster.IsAlive)
        {
            Logger.Log("Hunters have won the game!");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Evaluates the game state to determine if the game should end.
    /// </summary>
    /// <param name="monster">The monster player.</param>
    /// <returns>True if the game should end, otherwise false.</returns>
    public static bool EvaluateGameEnd(MonsterClass monster)
    {
        return CheckMonsterWinCondition(monster) || CheckHunterWinCondition(monster);
    }

    /// <summary>
    /// Adjusts game balance dynamically based on current game state.
    /// </summary>
    /// <param name="players">List of all players in the game.</param>
    public static void DynamicBalanceAdjustments(PlayerBase[] players)
    {
        // Example dynamic adjustment: Increase monster speed if monster health is below 50%
        if (monster.Health < Configurations.MonsterHealth * 0.5)
        {
            monster.Speed += 0.1f;
            Logger.Log("Increased monster speed for balance.");
        }

        // Example dynamic adjustment: Decrease hunter speed if monster is too far ahead in objectives
        foreach (var player in players)
        {
            if (player is HunterClass hunter)
            {
                hunter.Speed -= 0.05f;
                Logger.Log("Decreased hunter speed for balance.");
            }
        }
    }
}
