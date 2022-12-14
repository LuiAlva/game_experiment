using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestUI : MonoBehaviour
{
    public PC_Main PC;
    [SerializeField] TMP_Text MovementStateText;
    [SerializeField] TMP_Text MoveSpeedText;
    [SerializeField] TMP_Text DirectionText;
    [SerializeField] TMP_Text FacingText;
    [SerializeField] TMP_Text PositionText;
    [SerializeField] TMP_Text ActionStateText;
    [SerializeField] TMP_Text StatusEffectListText;
    [SerializeField] TMP_Text TestText;

    public void UpdateMovementStateText(string txt)
    {
        if (txt.Equals(MovementStateText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        MovementStateText.text = $"Movement: {txt}";
    }

    public void UpdateMoveSpeedText(string txt)
    {
        if (txt.Equals(MoveSpeedText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        MoveSpeedText.text = $"{txt}";
    }

    public void UpdateMoveDirectionText(string txt)
    {
        if (txt.Equals(DirectionText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        DirectionText.text = $"{txt}";
    }

    public void UpdateFacingDirectionText(string txt)
    {
        if (txt.Equals(PositionText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        FacingText.text = $"Facing: {txt}";
    }

    public void UpdatePositionText(string txt)
    {
        if (txt.Equals(PositionText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        PositionText.text = $"Position: {txt}";
    }

    public void UpdateActionStateText(string txt)
    {
        if (txt.Equals(ActionStateText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        ActionStateText.text = $"Action State: {txt}";
    }

    public void UpdateStatusEffectListText(string txt)
    {
        if (txt.Equals(StatusEffectListText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        StatusEffectListText.text = $"Status Effect List: {txt}";
    }

    public void UpdateTestText(string txt)
    {
        if (txt.Equals(TestText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        TestText.text = $"Test: {txt}";
    }

    [SerializeField] TMP_Text ConstitutionText;
    [SerializeField] TMP_Text StrengthText;
    [SerializeField] TMP_Text DexterityText;
    [SerializeField] TMP_Text IntelligenceText;
    [SerializeField] TMP_Text DefenseText;

    public void UpdateConstitutionText(string txt)
    {
        if (txt.Equals(ConstitutionText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        ConstitutionText.text = $"Constitution >> {txt}";
    }

    public void UpdateStrengthText(string txt)
    {
        if (txt.Equals(StrengthText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        StrengthText.text = $"Strength       >> {txt}";
    }

    public void UpdateDexterityText(string txt)
    {
        if (txt.Equals(DexterityText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        DexterityText.text = $"Dexterity       >> {txt}";
    }

    public void UpdateIntelligenceText(string txt)
    {
        if (txt.Equals(IntelligenceText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        IntelligenceText.text = $"Intelligence   >> {txt}";
    }

    public void UpdateDefenseText(string txt)
    {
        if (txt.Equals(DefenseText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        DefenseText.text = $"Defense        >> {txt}";
    }

    [SerializeField] TMP_Text HealthText;
    [SerializeField] TMP_Text StaminaText;
    [SerializeField] TMP_Text ManaText;

    public void UpdateHealthText(string txt)
    {
        if (txt.Equals(HealthText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        HealthText.text = $"Health    >> {txt}";
    }

    public void UpdateStaminaText(string txt)
    {
        if (txt.Equals(StaminaText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        StaminaText.text = $"Stamina >> {txt}";
    }

    public void UpdateManaText(string txt)
    {
        if (txt.Equals(ManaText.text)) { return; }
        if (txt.Equals(null)) { txt = "Error"; }
        ManaText.text = $"Mana      >> {txt}";
    }
}
