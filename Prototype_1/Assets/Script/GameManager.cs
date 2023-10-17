using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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


    public void LevelUp()
    {
        level++;
        Exp -= MaxExp;
        Lvtext.text = "Lv. "+ level;
        GameManager.GameManagerthis.ExpGage.fillAmount = GameManager.GameManagerthis.Exp / GameManager.GameManagerthis.MaxExp;
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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
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
                Debug.Log(Wave[WaveCount].EnemyCount[i]);
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
