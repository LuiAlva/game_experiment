public class PC_Speed
{
    Stat dexterity;

    float _movementSpeedStateMultiplier;
    float _baseSpeed = 2.5f;
    float _bonusSpeed = 0f;

    public PC_Speed(PC_Main pc)
    {
        dexterity = pc.Stats.Dexterity;
        _movementSpeedStateMultiplier = 1f;
    }

    public float GetCurrentSpeed()
    {
        return (speedFromDexterity() * _movementSpeedStateMultiplier) + _bonusSpeed;
    }

    public void SetBonusSpeed(float value) => _bonusSpeed = value;
    public void SetMovementSpeedStateMultiplier(float multiplier) => _movementSpeedStateMultiplier = multiplier;

    float speedFromDexterity()
    {
        return (dexterity.Value / 22) + _baseSpeed;
    }

}
