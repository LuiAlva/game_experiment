using System.Collections.Generic;
using System.Text;
using CustomExtensions;

public class StatusEffects
{
    public PC_Main PC;
    public List<StatusEffect> ActiveEffects = new List<StatusEffect>();
    List<StatusEffect> removedEffects = new List<StatusEffect>();

    public StatusEffects(PC_Main pc)
    {
        PC = pc;
    }

    public void Update()
    {
        if(ActiveEffectsCount > 0)
        {
            foreach (StatusEffect effect in ActiveEffects) {effect.Update(); }
            removeEffects();
        }
    }

    public void AddEffect(StatusEffect newEffect)
    {
        StatusEffect oldEffect = FindEffect(newEffect.Name);
        if(oldEffect == null)
        {
            ActiveEffects.Add(newEffect);
            newEffect.Activate(PC, this);
            updateUI();
            return;
        }
        if (newEffect.Strength == oldEffect.Strength)
        {
            if (newEffect.StartTime > oldEffect.TimeLeft)
            {
                oldEffect.SetTimeLeft(newEffect.StartTime);
                return;
            }
            else { return; }
        }
        if (newEffect.Strength > oldEffect.Strength)
        {
            oldEffect.Cancel();
            removedEffects.Add(oldEffect);
            ActiveEffects.Add(newEffect);
            newEffect.Activate(PC, this);
            updateUI();
            return;
        }
        else { oldEffect.ExtendTimeLeft(newEffect.StartTime / 3); }
    }

    public bool RemoveEffect(StatusEffect effect)
    {
        effect = FindEffect(effect.Name);
        if(effect == null) { return false; }
        removedEffects.Add(effect);
        effect.Cancel();
        return true;
    }

    public int ActiveEffectsCount => ActiveEffects.Count;

    void removeEffects()
    {
        if (removedEffects.Count == 0) { return; }
        foreach (StatusEffect effect in removedEffects)
        {
            ActiveEffects.Remove(effect);
        }
        updateUI();
        removedEffects.Clear();
    }

    void updateUI()
    {
        if(ActiveEffectsCount == 0) { PC.TestUi.StatusEffectListText.LabeledText("Status Effects","None"); return; }
        StringBuilder sb = new StringBuilder();
        foreach (StatusEffect effect in ActiveEffects)
        {
            sb.Append($"{effect.Name} | ");
        }
        PC.TestUi.StatusEffectListText.LabeledText("Status Effects", sb.ToString().Remove(sb.Length - 3));
    }

    StatusEffect FindEffect(string EffectName)
    {
        if(ActiveEffectsCount == 0) { return null; }
        foreach (StatusEffect effect in ActiveEffects)
        {
            if (effect.Name.Equals(EffectName))
                return effect;
        }
        return null;
    }
}
