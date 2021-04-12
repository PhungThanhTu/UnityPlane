using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCharging : MonoBehaviour
{
    Transform gameUI;

    public GameObject prefabManabar;
    ValueBar manabar;

    // Skill Object
    public int skillId = 1;
    GameObject skillPrefab;

    public float CD = 10;
    float currentCD = 0;

    bool CDReady = false;
    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.Find("gameUI").transform;
        skillPrefab = Resources.Load("Skill/Skill" + skillId) as GameObject;
        prefabManabar = Resources.Load("UI/Mana") as GameObject;
        manabar = Instantiate(prefabManabar, gameUI).GetComponent<ValueBar>();
        manabar.SetMaxValue((int)CD);
    }

    // Update is called once per frame
    void Update()
    {   
        

        if(!CDReady)
        {
            currentCD += Time.deltaTime;
            if(currentCD >= CD)
            {
                currentCD = CD;
                CDReady = true;
            }
        }
        manabar.SetValue((int)currentCD);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastSkill();
        }
    }
    [ContextMenu("CAST")]
    public void CastSkill()
    {   
        if(CDReady)
        {
            currentCD = 0;
            CDReady = false;
            manabar.SetValue((int)currentCD);

            if (skillPrefab != null)
            {
                Debug.Log("Skill casted");
                Instantiate(skillPrefab, transform.position, Quaternion.identity);
            }
        }
       
        
    }


}
