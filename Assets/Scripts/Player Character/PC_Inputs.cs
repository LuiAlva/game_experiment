using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCharacter {
    public class PC_Inputs : MonoBehaviour
    {
        PC_Main PC;
        public Vector2 MovementInput;
        public Vector2 AimStickInput;
        public Vector2 AimMouseInput;

        PC_ActionDash Dash;
        PC_ActionCrouch Crouch;
        PC_ActionAttack Attack;

        StatusEffectSlow statusSlow;
        StatusEffectDefense statusDefense;

        private void Awake()
        {
            PC = GetComponent<PC_Main>();
        }

        private void Start()
        {
            statusSlow = new StatusEffectSlow();
            statusDefense = new StatusEffectDefense();
            Dash = new PC_ActionDash(PC);
            Crouch = new PC_ActionCrouch(PC);
            Attack = new PC_ActionAttack(PC);
        }

        private void FixedUpdate()
        {
            PC.Movement.Update();
            PC.Aim.Update(AimStickInput, AimMouseInput, MovementInput);
            Attack.Update();
            PC.StatusEffects.Update();
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed) { Attack.Activate(); }
            if (context.canceled) { Attack.End(); }
        }
        public void OnDash(InputAction.CallbackContext context)
        {
            if(context.performed) { Dash.Activate(); }
            if(context.canceled) { Dash.End(); }
        }
        public void OnSecondaryAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Secondary Action");
                PC.StatusEffects.AddEffect(statusSlow);
            }
            if (context.canceled) {  }
        }
        bool x = true;
        public void OnSkillOne(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Skill One");
                if (x) { PC.States.Movement.ChangeMedium(SM_Movement.Mediums.Water); x = false; }
                else { PC.States.Movement.ChangeMedium(SM_Movement.Mediums.Air); x = true; }
            }
            if (context.canceled) { PC.States.Movement.ChangeMedium(SM_Movement.Mediums.Land); }
        }
        public void OnSkillTwo(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Skill Two");
                PC.StatusEffects.AddEffect(statusDefense);
            }
            if (context.canceled) { }
        }
        public void OnSkillThree(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Skill Three"); }
            if (context.canceled) { }
        }
        public void OnUseItem(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Use Item"); PC.Stats.Dexterity.AddToBase(1); }
            if (context.canceled) { }
        }
        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.performed) { Crouch.Activate(); }
            if (context.canceled) { Crouch.End(); }
        }
        public void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Dodge"); PC.Stats.Dexterity.AddToBase(-1); }
            if (context.canceled) { }
        }
        public void OnSkillToggle(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Skill Toggle"); }
            if (context.canceled) { }
        }
        public void OnChangeItem(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            if (context.performed)
            {
                if(value == 120 || value == 1) // Scroll wheel UP & Right D-PAD
                {
                    Debug.Log("Change Item Up");
                    PC.Stats.Constitution.AddToBase(1);
                }
                if(value == -120 || value == -1) // Scroll wheel DOWN & Left D-PAD
                {
                    Debug.Log("Change Item Down");
                    PC.Stats.Constitution.AddToBase(-1);
                }
            }
            if (context.canceled) { }
        }
        public void OnChangeActions(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            if (context.performed)
            {
                if (value == 1) //Key 2 & Up D-PAD
                {
                    Debug.Log("Change Action One");
                }
                if (value == -1) //Key 1 & Down D-PAD
                {
                    Debug.Log("Change Action Two");
                }
            }
            if (context.canceled) { }
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Interact"); }
            if (context.canceled) { }
        }
        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Pause"); }
            if (context.canceled) { }
        }
        public void OnAimStick(InputAction.CallbackContext context)
        {
            AimStickInput = context.ReadValue<Vector2>();
        }
        public void OnAimMouse(InputAction.CallbackContext context)
        {
            AimMouseInput = context.ReadValue<Vector2>();
        }
        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

    }
}
