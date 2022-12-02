using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public class PC_Movement
    {
        PC_Main PC;
        PC_Speed Speed;
        Vector2 directionMovement;
        Vector2 frozenDirection;
        float timerFrozenDirection;
        bool _isMoving;

        public PC_Movement(PC_Main pc)
        {
            PC = pc;
            Speed = pc.Speed;
            directionMovement = Vector2.zero;
            frozenDirection = directionMovement;
        }

        public void Update()
        {
            float currentSpeed = Speed.GetCurrentSpeed();
            PC.TestUi.UpdateActionStateText($"Speed:: {currentSpeed}");
            FindDirection();
            PC.RigidBody.MovePosition((Vector2)PC.transform.position + (directionMovement * currentSpeed * Time.deltaTime));
            PC.AnimatorBody.SetFloat("Velocity", directionMovement.sqrMagnitude * 1); // Replace 1 with animation speed???
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
