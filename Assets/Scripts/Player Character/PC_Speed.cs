using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Speed
{
    PC_Main PC;
    Stat dexterity;

    float _movementSpeedStateMultiplier;
    float _movementTypeStateMultiplier = 1f;
    float _baseSpeed = 2.5f;
    float _bonusSpeed = 0f;

    public PC_Speed(PC_Main pc)
    {
        PC = pc;
        dexterity = pc.Stats.Dexterity;
        _movementSpeedStateMultiplier = 1f;
    }

    public float GetCurrentSpeed()
    {
        return (speedFromDexterity() * _movementSpeedStateMultiplier * _movementTypeStateMultiplier) + _bonusSpeed;
    }

    public void SetBonusSpeed(float value) => _bonusSpeed = value;
    public void SetMovementSpeedStateMultipler(float multiplier) => _movementSpeedStateMultiplier = multiplier;
    public void SetMovementTypeStateMultiplier(float multipleir) => _movementTypeStateMultiplier = multipleir;

    float speedFromDexterity()
    {
        return (dexterity.Value / 22) + _baseSpeed;
    }

}
