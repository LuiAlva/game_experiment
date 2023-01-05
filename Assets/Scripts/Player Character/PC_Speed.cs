using UnityEngine;

public class PC_Speed
{
    Stat dexterity;

    float _movementSpeedStateMultiplier;
    float _baseSpeed = 2.5f;
    float _statusSpeed = 1f;
    float speedFromDexterity => (dexterity.Value / 22) + _baseSpeed;
    public float Current { get { return speedFromDexterity * _movementSpeedStateMultiplier * _statusSpeed; } }
    public PC_Speed(PC_Main pc)
    {
        dexterity = pc.Stats.Dexterity;
        _movementSpeedStateMultiplier = 1f;
    }
    public void SetMovementStateMultiplier(float multiplier) => _movementSpeedStateMultiplier = multiplier;
    public void AddSpeedPercentage(float amount) => _statusSpeed = Mathf.Clamp(_statusSpeed + amount, 0.2f, 2f);

}