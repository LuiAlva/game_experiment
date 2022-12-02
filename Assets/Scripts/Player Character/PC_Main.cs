using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCharacter;

public class PC_Main : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public Animator AnimatorBody;
    public GameObject AimPivot;
    public SpriteRenderer AimSprite;
    public TestUI TestUi;

    public PC_States States;
    public PC_Inputs Inputs;
    public PC_Movement Movement;
    public PC_Speed Speed;
    public PC_Aim Aim;
    public Stats Stats;
    public PC_Resources Resources;

    void Awake()
    {
        AnimatorBody = GetComponentInChildren<Animator>();
        RigidBody = GetComponent<Rigidbody2D>();
        Inputs = GetComponent<PC_Inputs>();
        Stats = new Stats(this);
        Stats.SetupStats(5, 3, 10, 4);
        Resources = new PC_Resources(this);
        States = new PC_States(this);
        Speed = new PC_Speed(this);
        Movement = new PC_Movement(this);
        Aim = new PC_Aim(this);
    }

    // Update is called once per frame
    void Update()
    {
        Stats.Update();
        Resources.Update();
    }

    public void RefreshGameObjectVariables()
    {
        AnimatorBody = GetComponentInChildren<Animator>();
    }
}
