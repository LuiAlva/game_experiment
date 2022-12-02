using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Speed
{
    PC_Main PC;
    Stat dexterity;
    SM_MovementSpeed speedStates;

    float _movementTypeSpeedMultiplier;
    float _baseSpeed = 2.5f;
    float _bonusSpeed = 0f;

    public enum SpeedType
    {
        Idle,
        Leisurely,
        Hasty,
        Sneaky,
        Weary
    }

    public PC_Speed(PC_Main pc)
    {
        PC = pc;
        dexterity = pc.Stats.Dexterity;
        speedStates = pc.States.MovementSpeedMachine;
        _movementTypeSpeedMultiplier = 1f;
    }

    public float GetCurrentSpeed()
    {
        return (speedFromDexterity() * _movementTypeSpeedMultiplier) + _bonusSpeed;
    }

    public void ChangeSpeedState(SpeedType speedType)
    {
        if (speedStates.ChangeState(speedStates.stateList[speedType.ToString()]))
        {
            PC.TestUi.UpdateMovementStateText(speedType.ToString());
            switch (speedType.ToString()){
                case "Hasty":
                    _movementTypeSpeedMultiplier = 1.5f;
                    break;
                case "Leisurely":
                    _movementTypeSpeedMultiplier = 1f;
                    break;
                case "Sneaky":
                    _movementTypeSpeedMultiplier = 0.7f;
                    break;
                case "Weary":
                    _movementTypeSpeedMultiplier = 0.5f;
                    break;
            }
        }
    }
    public void SetBonusSpeed(float value) => _bonusSpeed = value;

    public void SetMovementTypeSpeedMultipler(float multiplier)
    {
        _movementTypeSpeedMultiplier = multiplier;
    }

    float speedFromDexterity()
    {
        return (dexterity.Value / 22) + _baseSpeed;
    }

}
