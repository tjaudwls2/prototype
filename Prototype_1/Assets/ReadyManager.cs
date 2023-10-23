using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class team
{
    public GameObject partner; // ������ ����
    public skill[] partner_skill; //��Ʈ�ʽ�ų
}

public class ReadyManager : MonoBehaviour
{
    public adventure_Manager adventure_Manager;
    public SkillManager skillManager;
    public Event stats;

    private static ReadyManager readyManager = null;
    void Awake()
    {
        if (null == readyManager)
        {
            readyManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += Set_stat;
        SceneManager.sceneLoaded += playerfind;
        adventure_Manager = GetComponent<adventure_Manager>();

    }

    public void playerfind(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.Find("Player") != null)
            skillManager.player = GameObject.Find("Player").GetComponent<Player>();
    }
    public static ReadyManager readyManagerthis
    {
        get
        {
            if (null == readyManager)
            {
                return null;
            }
            return readyManager;
        }
    }
    public team[] myteam;

    public Character stat_Save_dumb;//��������� ����
    public Player player;
    public List<Quest_Class> have_quest;
    public void Set_stat(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            player.hp = stat_Save_dumb.hp;
            player.maxhp = stat_Save_dumb.maxhp;
            player.speed = stat_Save_dumb.speed;
            player.attack_Power = stat_Save_dumb.attack_Power;
            player.attack_Speed = stat_Save_dumb.attack_Speed;
            player.attack_Cooltime = stat_Save_dumb.attack_Cooltime;
            player.defense = stat_Save_dumb.defense;
        }
  

    }
    

    
  


}
