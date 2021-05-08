using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillState
{
    InShop,
    InUse,
    UnUse,
}
public enum Currency
{
    Star,
    Diamond,
}

[CreateAssetMenu(fileName = "playerData", menuName = "playerData")]

public class PlayerData : ScriptableObject
{
    public int Star = 0;
    public int Diamond = 0;
    public SkillList skilldata;


    string jsonSkillData;

    public void ToPrefs()
    {
        PlayerPrefs.SetInt("Star", Star);
        PlayerPrefs.SetInt("Diamond", Diamond);

        jsonSkillData = JsonUtility.ToJson(skilldata);
        PlayerPrefs.SetString("Skills", jsonSkillData);
    }
    public void FromPrefs()
    {
        if(!PlayerPrefs.HasKey("Star"))
        {
            ToPrefs();
        }
        Star = PlayerPrefs.GetInt("Star");
        Diamond = PlayerPrefs.GetInt("Diamond");
        jsonSkillData = PlayerPrefs.GetString("Skills");
        skilldata = JsonUtility.FromJson<SkillList>(jsonSkillData);

        
    }

    public void AddStar(int Amount)
    {
        Star += Amount;
    }
    public bool PayStar(int Amount)
    {
        if(Star < Amount)
        {
            return false;
        }
        Star -= Amount;
        return true;
    }
    public void AddDiamond(int Amount)
    {
        Diamond += Amount;
    }
    public bool PayDiamond(int Amount)
    {
        if(Diamond < Amount)
        {
            return false;
        }
        Diamond -= Amount;
        return true;
     
    }

}

[System.Serializable]
public class SkillList
{
    public List<Skill> skillList;
}



