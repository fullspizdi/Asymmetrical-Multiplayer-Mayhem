using System;
using System.Collections.Generic;

/// <summary>
/// AbilitySystem class to manage abilities for different player types.
/// </summary>
public static class AbilitySystem
{
    /// <summary>
    /// Dictionary to hold the abilities for the Monster.
    /// </summary>
    private static Dictionary<string, Action<MonsterClass>> monsterAbilities = new Dictionary<string, Action<MonsterClass>>
    {
        {"Attack", monster => monster.Attack()},
        {"Roar", monster => monster.Roar()}
    };

    /// <summary>
    /// Dictionary to hold the abilities for the Hunters.
    /// </summary>
    private static Dictionary<string, Action<HunterClass>> hunterAbilities = new Dictionary<string, Action<HunterClass>>
    {
        {"SetTrap", hunter => hunter.SetTrap()},
        {"Heal", hunter => hunter.Heal()}
    };

    /// <summary>
    /// Executes a specified ability for a Monster.
    /// </summary>
    /// <param name="monster">The monster executing the ability.</param>
    /// <param name="abilityName">The name of the ability to execute.</param>
    public static void ExecuteMonsterAbility(MonsterClass monster, string abilityName)
    {
        if (monsterAbilities.TryGetValue(abilityName, out var action))
        {
            action(monster);
            Logger.Log($"Monster {monster.Name} executed ability: {abilityName}");
        }
        else
        {
            Logger.LogError($"Invalid ability name: {abilityName} for Monster.");
        }
    }

    /// <summary>
    /// Executes a specified ability for a Hunter.
    /// </summary>
    /// <param name="hunter">The hunter executing the ability.</param>
    /// <param name="abilityName">The name of the ability to execute.</param>
    public static void ExecuteHunterAbility(HunterClass hunter, string abilityName)
    {
        if (hunterAbilities.TryGetValue(abilityName, out var action))
        {
            action(hunter);
            Logger.Log($"Hunter {hunter.Name} executed ability: {abilityName}");
        }
        else
        {
            Logger.LogError($"Invalid ability name: {abilityName} for Hunter.");
        }
    }
}
