using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public class PC_Movement
    {
        PC_Main PC;
        Vector2 directionMovement;
        float _speedRate;
        float _speedActionMultiplier;
        Vector2 frozenDirection;
        float timerFrozenDirection;
        bool _isMoving;

        //BonusStat Agility;
        int Agility = 3;

        public PC_Movement(PC_Main pc)
        {
            PC = pc;
            _speedRate = 1f;
            _speedActionMultiplier = 1f;
            directionMovement = Vector2.zero;
            frozenDirection = directionMovement;
        }

        public void Update()
        {
            FindDirection();
            PC.RigidBody.MovePosition((Vector2)PC.transform.position + (directionMovement * /*Agility.FinalValue*/ Agility * _speedRate * _speedActionMultiplier * Time.deltaTime));
            PC.AnimatorBody.SetFloat("Velocity", directionMovement.sqrMagnitude * _speedRate);
            //PC.AnimatorBody.SetFloat("Move X", directionMovement.x);
            //PC.AnimatorBody.SetFloat("Move Y", directionMovement.y);
        }

        public void Freeze(bool isFrozen) => PC.AnimatorBody.SetBool("Frozen", isFrozen);

        public bool FreezeDirection(float time)
        {
            if (IsMoving)
            {
                timerFrozenDirection = time;
                frozenDirection = directionMovement;
                return true;
            }
            else { return false; }
        }

        public void SetSpeedRate(float rate) { _speedRate = rate; }
        public void SetSpeedActionMultiplier(float multiplier) { _speedActionMultiplier = multiplier; }

        public bool IsMoving => _isMoving;

        void FindDirection()
        {
            if (timerFrozenDirection > 0) { timerFrozenDirection -= Time.deltaTime; }

            if (timerFrozenDirection > 0)
            {
                if (directionMovement != frozenDirection)
                {
                    directionMovement = frozenDirection;
                }
            }
            else { directionMovement = PC.Inputs.MovementInput; }

            if (PC.AnimatorBody.GetBool("Frozen"))
            {
                if (timerFrozenDirection > 0) { timerFrozenDirection = 0; }
                directionMovement = Vector2.zero;
                _isMoving = false;
            }
            _isMoving = !(directionMovement == Vector2.zero);
        }
    }
}
