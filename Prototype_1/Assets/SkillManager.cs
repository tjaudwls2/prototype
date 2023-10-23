using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class skillevent : UnityEvent<int> { }


[System.Serializable]
public class skill
{
    public string name;
    public Sprite img;
    public string[] skillex;
    public skillevent skill_Function;
    public int power_up;
    public bool Lock;
}

public class SkillManager : MonoBehaviour
{


    public List<skill> skill_list;   //모든 스킬 리스트
    public List<skill> Player_skills;//보유한 특성
    public Character player;

    private static SkillManager skillManager = null;
    void Awake()
    {
        if (null == skillManager)
        {
            skillManager = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach (skill skill in skill_list)
        {
            if (!skill.Lock)
            {
                Player_skills.Add(skill);
            }
        }



    }
    public static SkillManager SkillManagerthis
    {
        get
        {
            if (null == skillManager)
            {
                return null;
            }
            return skillManager;
        }
    }
    public void playerfind()
    {
        player = GameObject.Find("Player").GetComponent<Character>();
    }


    public GameObject Fire_prefab;
    public void Fire(int power)
    {
        switch (power)
        {
           case 0:Instantiate(Fire_prefab,player.transform); break;
          
           case 1: break;
          
           case 2: break;
          
           case 3: break;
          
           case 4: break;
        }
      





    }
    public void HP_PowerUP(int power)
    {

        switch (power)
        {
            case 0: break;

            case 1: break;

            case 2: break;

            case 3: break;

            case 4: break;
        }

    }
    public void Speed_PowerUP(int power)
    {

        switch (power)
        {
            case 0: break;

            case 1: break;

            case 2: break;

            case 3: break;

            case 4: break;
        }

    }
    public void Attack_Speed_PowerUP(int power)
    {

        switch (power)
        {
            case 0: break;

            case 1: break;

            case 2: break;

            case 3: break;

            case 4: break;
        }

    }


}
