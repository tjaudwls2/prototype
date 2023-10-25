using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;

public class GameManager : MonoBehaviour
{

    public float time_Max;
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
    
    public QuestManager QuestManager;
    public float time_check;

    private void Start()
    {
        StartCoroutine("checkQC");
    }
    IEnumerator checkQC()
    {
        while (true)
        {
   
            QuestManager.Quest_Check(time_check);


            yield return new WaitForSeconds(30f);
        }


    }
    public TextMeshProUGUI time_text;

    private void Update()
    {
        time_check += Time.deltaTime;
        float x = time_Max - time_check;
        time_text.text = ((int)x/60%60).ToString("D2") + " : "+((int)x%60).ToString("D2");

    }
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
        int x = EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().skillid;

        EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill.skill_Function.Invoke(x);// EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill.power_up);
         SkillManager.SkillManagerthis.Player_skills.Find(x => x == EventSystem.current.currentSelectedGameObject.GetComponent<skillbtn>().thisskill).power_up[x] =true;
        LevelUpUI.GetComponent<Animator>().SetTrigger("End");
    }

    public void Comparison(int i,skill selectskill, int a, int b)
    {
        if (three_SB != null)
        {
            foreach (skillbtn sb in three_SB)
            {
                if (sb.thisskill.name == selectskill.name)
                {
                    if (sb.skillid == a)
                    {
                        LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid = b;
                    }
                    if (sb.skillid == b)
                    {
                        LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid = a;
                    }
                }
            }
        }
    }


    public List<skillbtn> three_SB=new List<skillbtn>();
   public  List<skill> skills = new List<skill>();
    public void Skill_List_Setting()
    {
        if(three_SB!=null)
        three_SB.Clear();
        skills.Clear();
        foreach (skill skill in SkillManager.SkillManagerthis.Player_skills)//락이 걸려있는지 확인 
        {
            if (!skill.power_up[2] && !skill.power_up[3] && !skill.power_up[4] && !skill.power_up[5])
            {
                if (!skill.Lock[1])
                {
                    skills.Add(skill);
                    skills.Add(skill);
                }
                else
                {
                    if (!skill.power_up[0] && !skill.power_up[1])
                    {
                        skills.Add(skill);
                        skills.Add(skill);
                    }

                }
            }
        }





        for (int i = 0; i < 3; i++)
        {
            LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.SetActive(false);
        }
        int y = Mathf.Clamp(skills.Count, 0, 3);
        for (int i = 0; i < y; i++)
        {
            LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.SetActive(true);
            skill selectskill = skills[Random.Range(0, skills.Count)];

            if (!selectskill.power_up[0] && !selectskill.power_up[1])
            {
                LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid = Random.Range(0, 2);

                Comparison(i, selectskill, 0, 1);
            }
            else if (selectskill.power_up[0])
            {
                LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid = Random.Range(2, 4);
                Comparison(i, selectskill, 2, 3);
            }
            else if (selectskill.power_up[1])
            {
                LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid = Random.Range(4, 6);
                Comparison(i, selectskill, 4, 5);
            }
            skills.Remove(selectskill);
            three_SB.Add(LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>());
            LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().thisskill = selectskill;
            LevelUpUI.transform.Find("three_skill").GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = selectskill.name;
            LevelUpUI.transform.Find("three_skill").GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = selectskill.skillex[LevelUpUI.transform.Find("three_skill").GetChild(i).gameObject.GetComponent<skillbtn>().skillid];
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

    public void goTown()
    {
        SceneManager.LoadScene(0);
    }
}
