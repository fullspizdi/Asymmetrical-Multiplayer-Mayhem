using System;
using System.Collections.Generic;

/// <summary>
/// Configurations class for managing game settings and constants.
/// </summary>
public static class Configurations
{
    // Game settings
    public static readonly int MaxPlayers = 5;
    public static readonly int MonsterHealth = 1000;
    public static readonly int HunterHealth = 300;
    public static readonly float MonsterSpeed = 1.5f;
    public static readonly float HunterSpeed = 1.0f;
    public static readonly int GameDurationInSeconds = 900; // 15 minutes

    // Ability cooldowns in seconds
    public static readonly Dictionary<string, float> AbilityCooldowns = new Dictionary<string, float>
    {
        {"MonsterAttack", 5.0f},
        {"HunterTrap", 10.0f},
        {"HunterHeal", 20.0f}
    };

    // Network settings
    public static readonly string ServerIP = "127.0.0.1";
    public static readonly int ServerPort = 8080;

    /// <summary>
    /// Initializes the game configurations.
    /// </summary>
    static Configurations()
    {
        Logger.Log("Initializing game configurations.");
        ValidateSettings();
    }

    /// <summary>
    /// Validates the game settings to ensure they are within acceptable limits.
    /// </summary>
    private static void ValidateSettings()
    {
        if (MonsterHealth <= 0 || HunterHealth <= 0)
        {
            Logger.LogError("Health settings must be greater than 0.");
            throw new InvalidOperationException("Health settings must be greater than 0.");
        }

        if (MonsterSpeed <= 0 || HunterSpeed <= 0)
        {
            Logger.LogError("Speed settings must be greater than 0.");
            throw new InvalidOperationException("Speed settings must be greater than 0.");
        }

        if (GameDurationInSeconds <= 0)
        {
            Logger.LogError("Game duration must be greater than 0 seconds.");
            throw new InvalidOperationException("Game duration must be greater than 0 seconds.");
        }

        Logger.Log("Game settings validated successfully.");
    }
}
