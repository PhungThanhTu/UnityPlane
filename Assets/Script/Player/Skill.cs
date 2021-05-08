using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill : ScriptableObject
{
    public SkillState skillstate;
    public Currency currency;

    public int id;
    public int price;
    public GameObject skillPrefab;
    public Sprite skillImage;

   public void LoadResource()
    {
        skillPrefab = Resources.Load("Skills/Skill" + id + " / Skill") as GameObject;
        skillImage = Resources.Load("Skills/Skill" + id + "/Sprite") as Sprite;
    }
       
    


}
