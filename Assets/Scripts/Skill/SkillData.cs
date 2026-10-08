using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "ALEATOR/Skill")]

public class SkillData : ScriptableObject
{
    
    [SerializeField] private string _skillName;
    [SerializeField] private string _description;
    [SerializeField] private SkillEffectType _effectType;
    [SerializeField] private float _effectValue;
    [SerializeField] private int _basePrice = 100;
    public string SkillName => _skillName;
    public string Description => _description;
    public float EffectValue => _effectValue;
    public SkillEffectType EffectType => _effectType;
    public int BasePrice => _basePrice;

    public enum SkillEffectType
    {
        ScoreMultiplier,
        DiceModifier,
        RequiredScoreModifier
    }

}
