using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public class PC_Aim
    {
        PC_Main PC;
        bool ManualAiming;
        public bool HoldingPosition { get; set; }
        public Vector2 AimDirection { get; set; }
        public int FacingDirection { get; set; }
        public string CharacterFacingDirection { get; set; }
        int lastAimDirection = 0;

        // Sprite
        float HideTimer = 0f;
        float HideTime = 0.8f;

        // Mouse Positioning
        float AimAngle;

        // Idle
        public bool MouseIdle { get; private set; }
        Vector2 LastMousePosition;
        float IdleTimer;
        float TimeBeforeIdle = 2.8f;

        public PC_Aim(PC_Main playerCharacter)
        {
            PC = playerCharacter;
            HoldingPosition = false;
        }

        public void Update(Vector2 AimStickInput, Vector2 MouseInput, Vector2 MovementInput)
        {
            CheckMouseIdle(MouseInput);

            if (!HoldingPosition)
            {
                if (AimStickInput != Vector2.zero)
                {
                    if (!ManualAiming) { ManualAiming = true; }
                    StickAim(AimStickInput);
                }
                else if (!MouseIdle)
                {
                    if (!ManualAiming) { ManualAiming = true; }
                    MouseAim(Camera.main.ScreenToWorldPoint(MouseInput));
                }
                else if (MovementInput.sqrMagnitude > 0)
                {
                    if (ManualAiming) { ManualAiming = false; }
                    StickAim(MovementInput);
                }
                else if (ManualAiming) { ManualAiming = false; }
            }
            HideAimSprite();
            AnimationDirection();
        }

        void StickAim(Vector2 StickInput)
        {
            AimDirection = StickInput;
            AimAngle = Mathf.Atan2(-AimDirection.x, AimDirection.y) * Mathf.Rad2Deg;
            PC.AimPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, AimAngle));
        }

        void MouseAim(Vector3 MouseWorldPosition)
        {
            AimDirection = new Vector2(MouseWorldPosition.x - PC.transform.position.x, MouseWorldPosition.y - PC.transform.position.y);
            AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg -90;
            if(AimAngle < -179.99) { AimAngle += 360; }
            PC.AimPivot.transform.rotation = Quaternion.AngleAxis(AimAngle, Vector3.forward);
        }

        void HideAimSprite()
        {
            if (ManualAiming && PC.AimSprite.color.a < 100)
            {
                PC.AimSprite.color += new Color(0, 0, 0, 100 - PC.AimSprite.color.a);
                HideTimer = HideTime;
            }

            if (!ManualAiming && HideTimer > 0.0f && PC.AimSprite.color.a > 0)
            {
                HideTimer -= Time.deltaTime;
                if (HideTimer < 0) { HideTimer = 0; }
                //PC.AimSprite.color = new Color(PC.AimSprite.color.r, PC.AimSprite.color.g, PC.AimSprite.color.b, (int)(100 * (HideTimer / HideTime)));
                PC.AimSprite.color -= new Color(0, 0, 0, (int)(PC.AimSprite.color.a - (100 * (HideTimer/HideTime))));
            }
        }

        void CheckMouseIdle(Vector2 MousePosition)
        {
            if (LastMousePosition == MousePosition)
            {
                if (IdleTimer > 0)
                {
                    IdleTimer -= Time.deltaTime;
                    if (IdleTimer < 0) { IdleTimer = 0; }
                }
                if (IdleTimer == 0 && !MouseIdle) { MouseIdle = true; }
            }
            else
            {
                if (MouseIdle) { MouseIdle = false; }
                LastMousePosition = MousePosition;
                if (IdleTimer < TimeBeforeIdle) { IdleTimer = TimeBeforeIdle; }
            }
        }

        void AnimationDirection1()
        {
            if (AimDirection == Vector2.zero) { return; }
            PC.TestUi.UpdateTestText($"y: {AimDirection.y} :: x {AimDirection.x} :: AimAngle {AimAngle}");
            if (System.Math.Abs(AimDirection.y) > System.Math.Abs(AimDirection.x))
            {
                if (AimDirection.y < 0) { FacingDirection = 0; } //Down
                else { FacingDirection = 3; } //Up
            }
            else
            {
                if (AimDirection.x < 0) { FacingDirection = 1; } //Left
                else { FacingDirection = 2; } //Right
            }
            if (AnimationDirectionChanged())
            {
                PC.AnimatorBody.SetFloat("Direction", FacingDirection);
            }
            CharacterFaceDirection();
        }

        void AnimationDirection()
        {
            if (AimDirection == Vector2.zero) { return; }
            if (AimAngle <= 44.999 && AimAngle >= -44.999) { FacingDirection = 3; } //Up
            else if(AimAngle <= 135 && AimAngle >= 45) { FacingDirection = 1; } //Left
            else if(AimAngle <= -45 && AimAngle >= -135) { FacingDirection = 2; } // Right
            else { FacingDirection = 0; } //Down
            if (AnimationDirectionChanged())
            {
                PC.AnimatorBody.SetFloat("Direction", FacingDirection);
            }
            CharacterFaceDirection();
        }

        void CharacterFaceDirection()
        {
            if (AimAngle <= 157.5 && AimAngle >= 112.4999) { CharacterFacingDirection = "South West"; }
            else if (AimAngle <= 112.5 && AimAngle >= 67.4999) { CharacterFacingDirection = "West"; }
            else if (AimAngle <= 67.5 && AimAngle >= 22.4999) { CharacterFacingDirection = "North West"; }
            else if (AimAngle <= 22.5 && AimAngle >= -22.4999) { CharacterFacingDirection = "North"; }
            else if (AimAngle <= -22.5 && AimAngle >= -67.4999) { CharacterFacingDirection = "North East"; }
            else if (AimAngle <= -67.5 && AimAngle >= -112.4999) { CharacterFacingDirection = "East"; }
            else if (AimAngle <= -112.5 && AimAngle >= -157.4999) { CharacterFacingDirection = "South East"; }
            else { CharacterFacingDirection = "South"; }
            PC.TestUi.UpdateCharacterDirectionText(CharacterFacingDirection);
        }



        bool AnimationDirectionChanged()
        {
            if (lastAimDirection == FacingDirection) { return false; }
            else { lastAimDirection = FacingDirection; return true; }
        }
    }
}
