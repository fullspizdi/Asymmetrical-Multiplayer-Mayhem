using System;

/// <summary>
/// Base class for all player types in the game.
/// </summary>
public abstract class PlayerBase
{
    public string Name { get; private set; }
    public int Health { get; protected set; }
    public float Speed { get; protected set; }
    public bool IsAlive => Health > 0;

    /// <summary>
    /// Constructor for PlayerBase.
    /// </summary>
    /// <param name="name">The name of the player.</param>
    /// <param name="health">The initial health of the player.</param>
    /// <param name="speed">The movement speed of the player.</param>
    public PlayerBase(string name, int health, float speed)
    {
        Name = name;
        Health = health;
        Speed = speed;
        Logger.Log($"Player {name} created with {health} health and {speed} speed.");
    }

    /// <summary>
    /// Method for the player to take damage.
    /// </summary>
    /// <param name="amount">The amount of damage to take.</param>
    public void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            Logger.LogError("Damage amount cannot be negative.");
            throw new ArgumentException("Damage amount cannot be negative.");
        }

        Health -= amount;
        Logger.Log($"{Name} took {amount} damage, remaining health: {Health}.");

        if (Health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Method for the player to heal.
    /// </summary>
    /// <param name="amount">The amount of health to restore.</param>
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            Logger.LogError("Heal amount cannot be negative.");
            throw new ArgumentException("Heal amount cannot be negative.");
        }

        Health += amount;
        Logger.Log($"{Name} healed {amount}, new health: {Health}.");
    }

    /// <summary>
    /// Method called when the player's health reaches zero.
    /// </summary>
    protected virtual void Die()
    {
        Logger.Log($"{Name} has died.");
    }

    /// <summary>
    /// Abstract method for player-specific actions to be implemented by derived classes.
    /// </summary>
    public abstract void PerformAction();
}
