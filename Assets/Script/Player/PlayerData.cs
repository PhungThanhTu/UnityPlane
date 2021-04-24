using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

[System.Serializable]
public class SkillList
{
    public List<SingleSkill> skills;
}


[System.Serializable]
public class SingleSkill
{
    public int id;
    public Sprite skillImage;
    public GameObject skillPrefab;
    public int price;
    public Currency currency;
    public SkillState state;

    public void LoadResources()
    {
        skillPrefab = Resources.Load("Skill" + id) as GameObject;
    }
}
