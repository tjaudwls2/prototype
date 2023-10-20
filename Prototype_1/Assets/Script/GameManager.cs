using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public GameObject enegry;
    public GameObject[] hiteff;
    Player player;
    public Vector3[] Spawnpos;
    public float Exp,MaxExp;
    public int level=1;

    public TextMeshProUGUI Lvtext;
    public Image ExpGage;
    public bool notTown;


    public GameObject LevelUpUI;


    public void LevelUp()
    {
        level++;
        Exp -= MaxExp;
        Lvtext.text = "Lv. "+ level;
        ExpGage.fillAmount =Exp /MaxExp;
        Skill_List_Setting();
        Time.timeScale = 0;
        LevelUpUI.SetActive(true);


    }
    public void selectSkill()
    {
        int x = EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill.power_up;

        EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill.skill_Function.Invoke(x);// EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill.power_up);
        SkillManager.SkillManagerthis.Player_skills.Find(x => x == EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill).power_up++;
        Time.timeScale = 1;
        LevelUpUI.GetComponent<Animator>().SetTrigger("End");
    }


    public void Skill_List_Setting()
    {
        List<skill> skills = new List<skill>();
        foreach(skill skill in SkillManager.SkillManagerthis.Player_skills)
        {
            if( skill.power_up != 5)
            skills.Add(skill);
        }

        for (int i = 0; i < 3; i++)
        {
            LevelUpUI.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < Mathf.Clamp(skills.Count,0,3); i++)
        {
     
            LevelUpUI.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            skill selectskill = SkillManager.SkillManagerthis.Player_skills[Random.Range(0, SkillManager.SkillManagerthis.Player_skills.Count)];
            skills.Remove(selectskill);
            LevelUpUI.transform.GetChild(0).GetChild(i).gameObject.GetComponent<skillbtn>().thisskill = selectskill;



        }
    }

    [System.Serializable]
    public class wave
    {
        public GameObject[] Enemy;
        public int[] EnemyCount;
    }

    public wave[] Wave;
    public int WaveCount;

    private static GameManager gameManager = null;
    void Awake()
    {
        if (null == gameManager)
        {
            gameManager = this;
      
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
       
        
        if(notTown)
        StartCoroutine(Spawn());
       
       

    }
    public static GameManager GameManagerthis
    {
        get
        {
            if (null == gameManager)
            {
                return null;
            }
            return gameManager;
        }
    }

    IEnumerator Spawn()
    {
       
        while (WaveCount < Wave.Length)
        {
            for (int i = 0; i < Wave[WaveCount].EnemyCount.Length; i++)
            {
             //   Debug.Log(Wave[WaveCount].EnemyCount[i]);
                for (int x = 0; x < Wave[WaveCount].EnemyCount[i]; x++)
                {
                    GameObject enemy = Instantiate(Wave[WaveCount].Enemy[i], transform.position, transform.rotation);
                    
                    enemy.transform.position =player.transform.position + Spawnpos[Random.Range(0,Spawnpos.Length)];


                }
            }
            WaveCount++;

            yield return new WaitForSeconds(10f);

        }





    }


}
