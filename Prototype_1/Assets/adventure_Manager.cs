using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quest_type
{
    버티기,
    잡기

}
[System.Serializable]
public class Enemy_Quset
{

    public GameObject Enemy;       //처치해야하는 적
    public int Count_Enemy;        //잡아야하는 수
}



[System.Serializable]
public class Quest_Class
{

    public string quest_Name;                           //퀘스트 이름
    public string quest_Ex;                             //퀘스트 설명
    public Quest_type quest_Type;                       //퀘스트 종류
    public float Count_Time;                            //퀘스트 클리어 조건(시간)
    public Enemy_Quset enemy_Quset;                     //퀘스트 클리어 조건(적처치)
    public bool quest_Clear;                            //클리어 했는가?
    public float compensation_Gold;                     //보상(골드)
    public string compensation_Skill_Name;              //보상(스킬)
    public string compensation_quset_Name;              //보상(?)(다음 퀘스트)
}

public class adventure_Manager : MonoBehaviour
{

    public List<Quest_Class> quset_Classes;  //모든 퀘스트
    public List<Quest_Class> quset_possible; //가능한 퀘스트 목록

    //클리어하지 않았지만 아직 깨면 안되는 미션
    private void Awake()
    {

        if(!quset_Classes[0].quest_Clear)
        quset_possible.Add(quset_Classes[0]);

        if (!quset_Classes[1].quest_Clear)
        quset_possible.Add(quset_Classes[1]);


    }





}
