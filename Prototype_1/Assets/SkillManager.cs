using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class skill
{
    public string name;
    public Sprite img;
    public string skillex;
    public UnityEvent skill_Function;
}

public class SkillManager : MonoBehaviour
{
    public skill[] Player_skills;
    public Character player;

    
    public void playerfind()
    {
        player = GameObject.Find("Player").GetComponent<Character>();
    }


    public void Attack_PowerUP()
    {
        playerfind();
        player.attack_Power += 10;

    }
    public void HP_PowerUP()
    {
        playerfind();
        player.maxhp += 10;
        player.hp += 10;

    }
    public void Speed_PowerUP()
    {
        playerfind();
        player.speed += 5;

    }
    public void Attack_Speed_PowerUP()
    {
        playerfind();
        player.attack_Speed += 5;

    }


}
