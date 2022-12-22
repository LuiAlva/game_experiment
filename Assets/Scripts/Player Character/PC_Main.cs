using UnityEngine;
using PlayerCharacter;

public class PC_Main : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public Animator AnimatorBody;
    public GameObject AimPivot;
    public SpriteRenderer AimSprite;
    public TestUI TestUi;

    public States States;
    public PC_Inputs Inputs;
    public PC_Movement Movement;
    public PC_Speed Speed;
    public PC_Aim Aim;
    public Stats Stats;
    public Resources Resources;

    void Awake()
    {
        AnimatorBody = GetComponentInChildren<Animator>();
        RigidBody = GetComponent<Rigidbody2D>();
        Inputs = GetComponent<PC_Inputs>();
        Stats = new Stats(this);
        Stats.SetupStats(10, 3, 10, 4);
        Resources = new Resources(this);
        Speed = new PC_Speed(this);
        Movement = new PC_Movement(this);
        Aim = new PC_Aim(this);
        States = new States(this);
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
