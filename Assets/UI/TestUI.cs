using UnityEngine;
using TMPro;
using CustomExtensions;

public class TestUI : MonoBehaviour
{
    public PC_Main PC;
    [field:Header("Character Data")]
    [field:SerializeField] public TMP_Text MovementStateText { get; private set; }
    [field:SerializeField] public TMP_Text MoveSpeedText { get; private set; }
    [field:SerializeField] public TMP_Text DirectionText { get; private set; }
    [field:SerializeField] public TMP_Text FacingText { get; private set; }
    [field:SerializeField] public TMP_Text PositionText { get; private set; }
    [field:SerializeField] public TMP_Text ActionStateText { get; private set; }
    [field:SerializeField] public TMP_Text StatusEffectListText { get; private set; }
    [field:SerializeField] public TMP_Text TestText { get; private set; }
    [field:Header("Stats")]
    [field: SerializeField] public TMP_Text ConstitutionText { get; private set; }
    [field: SerializeField] public TMP_Text StrengthText { get; private set; }
    [field: SerializeField] public TMP_Text DexterityText { get; private set; }
    [field: SerializeField] public TMP_Text IntelligenceText { get; private set; }
    [field: SerializeField] public TMP_Text DefenseText { get; private set; }
    [field: Header("Resources")]
    [field: SerializeField] public TMP_Text HealthText { get; private set; }
    [field: SerializeField] public TMP_Text StaminaText { get; private set; }
    [field: SerializeField] public TMP_Text ManaText { get; private set; }
}
