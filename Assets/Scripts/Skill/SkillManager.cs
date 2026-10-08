using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<SkillData> _debugOwnedSkills;
    [SerializeField] private SkillData _testSkill;
    [SerializeField] private int _maxSkillCount = 3;

    private void Start()
    {
        _debugOwnedSkills = RunSession.OwnedSkills;
        if (RunSession.CurrentStage == 1 && _testSkill != null)
        {
            AddSkill(_testSkill);
        }
        Debug.Log("所持スキル数：" + RunSession.OwnedSkills.Count);
    }

    public bool AddSkill(SkillData skill)
    {
        if(skill == null)
        {
            return false;
        }

        if(RunSession.OwnedSkills.Count >= _maxSkillCount)
        {
            return false;
        }
        RunSession.OwnedSkills.Add(skill);
        return true;
    }

    public int ApplyScoreEffects(int baseScore)
    {
        float temporaryScore = baseScore;

        foreach(SkillData skill in RunSession.OwnedSkills)
        {
            switch(skill.EffectType)
            {
                case SkillData.SkillEffectType.ScoreMultiplier:
                temporaryScore = temporaryScore * skill.EffectValue;
                break;
            }
            
        }
        return Mathf.RoundToInt(temporaryScore);

    }


}
