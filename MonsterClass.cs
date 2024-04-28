using System;

/// <summary>
/// Represents the Monster in the game, inheriting from PlayerBase.
/// </summary>
public class MonsterClass : PlayerBase
{
    /// <summary>
    /// Constructor for the MonsterClass.
    /// </summary>
    /// <param name="name">The name of the monster.</param>
    public MonsterClass(string name) : base(name, Configurations.MonsterHealth, Configurations.MonsterSpeed)
    {
        Logger.Log($"Monster {name} initialized.");
    }

    /// <summary>
    /// Monster-specific implementation of dying.
    /// </summary>
    protected override void Die()
    {
        base.Die();
        Logger.Log($"{Name} as Monster has been defeated.");
    }

    /// <summary>
    /// Monster's action method to perform its unique abilities.
    /// </summary>
    public override void PerformAction()
    {
        // Example action logic for the monster
        Logger.Log($"{Name} is performing a monstrous action!");

        // This could be expanded to include specific monster abilities
        Attack();
    }

    /// <summary>
    /// Simulates the monster attacking.
    /// </summary>
    private void Attack()
    {
        Logger.Log($"{Name} attacks with its mighty claws!");
        // Attack logic here
    }
}
