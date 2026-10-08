using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<SkillData> _skillPool = new();
    [SerializeField] private List<SkillData> _selectedSkills = new();
    [SerializeField] private SkillManager _skillManager;
    [SerializeField] private bool[] _isSold = new bool[3];
    
    private void Start()
    {
        SkillRandom();
    }

    public void SkillRandom()
    {
        if(_skillPool.Count < 3)
        {
            Debug.LogError("スキル候補が3種類未満です");
            return;
        }
        _selectedSkills.Clear();
        List<SkillData> skillPool = new List<SkillData>(_skillPool);
        for(int i = 0; i < 3 ; i++)
        {
            int index = Random.Range(0, skillPool.Count);
            _selectedSkills.Add(skillPool[index]);
            skillPool.RemoveAt(index); 
            
        }
        foreach (SkillData skill in _selectedSkills)
        {
            int price = CalculatePrice(skill);
            Debug.Log(skill.SkillName + " : " + price);
        }
        
    }

    public int CalculatePrice(SkillData skill)
    {
        int price = skill.BasePrice;
        int shopCount = (RunSession.CurrentStage - 1) / 3;
        price = price * Mathf.RoundToInt(Mathf.Pow(2, shopCount - 1));
        return price;
    }

    public bool BuySkill(int index)
    {
        
        if (index < 0 || index >= _selectedSkills.Count)
        {
            return false;
        }
        if (_isSold[index])
        {
            return false;
        }
        int price = CalculatePrice(_selectedSkills[index]);
        if (RunSession.WalletScore < price)
        {
            return false;
        }
        bool success = _skillManager.AddSkill(_selectedSkills[index]);
        if(success == false)
        {
            return false;
        }
        RunSession.WalletScore -= price;
        _isSold[index] = true;
        return true;

    }

}
