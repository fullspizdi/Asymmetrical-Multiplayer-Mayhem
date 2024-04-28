using System;

/// <summary>
/// Hunter class representing the hunter players in the game.
/// Inherits from PlayerBase and includes specific abilities and mechanics for hunters.
/// </summary>
public class HunterClass : PlayerBase
{
    // Abilities specific to the Hunter
    public float TrapCooldown { get; private set; }
    public float HealCooldown { get; private set; }

    /// <summary>
    /// Constructor for the HunterClass.
    /// </summary>
    /// <param name="name">The name of the hunter.</param>
    public HunterClass(string name) : base(name, Configurations.HunterHealth, Configurations.HunterSpeed)
    {
        TrapCooldown = Configurations.AbilityCooldowns["HunterTrap"];
        HealCooldown = Configurations.AbilityCooldowns["HunterHeal"];
        Logger.Log($"Hunter {name} initialized with Trap cooldown: {TrapCooldown}s and Heal cooldown: {HealCooldown}s.");
    }

    /// <summary>
    /// Sets a trap that can immobilize the monster temporarily.
    /// </summary>
    public void SetTrap()
    {
        if (TrapCooldown <= 0)
        {
            Logger.Log($"{Name} has set a trap.");
            // Reset cooldown
            TrapCooldown = Configurations.AbilityCooldowns["HunterTrap"];
        }
        else
        {
            Logger.LogError($"{Name} tried to set a trap but cooldown is not yet over.");
        }
    }

    /// <summary>
    /// Heals the hunter or an ally.
    /// </summary>
    public void Heal()
    {
        if (HealCooldown <= 0)
        {
            Health += 50; // Heal amount, can be adjusted or moved to configurations
            if (Health > Configurations.HunterHealth)
                Health = Configurations.HunterHealth;

            Logger.Log($"{Name} has healed.");
            // Reset cooldown
            HealCooldown = Configurations.AbilityCooldowns["HunterHeal"];
        }
        else
        {
            Logger.LogError($"{Name} tried to heal but cooldown is not yet over.");
        }
    }

    /// <summary>
    /// Updates the cooldowns for the hunter's abilities.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update.</param>
    public void UpdateCooldowns(float deltaTime)
    {
        if (TrapCooldown > 0)
            TrapCooldown -= deltaTime;
        if (HealCooldown > 0)
            HealCooldown -= deltaTime;
    }
}
