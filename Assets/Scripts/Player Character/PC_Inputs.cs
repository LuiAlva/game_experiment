
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
        PC_ActionAttack Attack;

        private void Awake()
        {
            PC = GetComponent<PC_Main>();
            Dash = new PC_ActionDash(PC);
            Attack = new PC_ActionAttack(PC);
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            PC.Movement.Update();
            PC.Aim.Update(AimStickInput, AimMouseInput, MovementInput);
            Attack.Update();
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
            if (context.performed) { Debug.Log("Secondary Action"); }
            if (context.canceled) {  }
        }
        public void OnSkillOne(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Skill One"); }
            if (context.canceled) { }
        }
        public void OnSkillTwo(InputAction.CallbackContext context)
        {
            if (context.performed) { Debug.Log("Skill Two"); }
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
            if (context.performed) { Debug.Log("Crouch"); }
            if (context.canceled) { }
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
