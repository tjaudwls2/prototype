using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quest_type
{
    ��Ƽ��,
    ���

}
[System.Serializable]
public class Enemy_Quset
{

    public GameObject Enemy;       //óġ�ؾ��ϴ� ��
    public int Count_Enemy;        //��ƾ��ϴ� ��
}



[System.Serializable]
public class Quest_Class
{

    public string quest_Name;                           //����Ʈ �̸�
    public string quest_Ex;                             //����Ʈ ����
    public Quest_type quest_Type;                       //����Ʈ ����
    public float Count_Time;                            //����Ʈ Ŭ���� ����(�ð�)
    public Enemy_Quset enemy_Quset;                     //����Ʈ Ŭ���� ����(��óġ)
    public bool quest_Clear;                            //Ŭ���� �ߴ°�?
    public float compensation_Gold;                     //����(���)
    public string compensation_Skill_Name;              //����(��ų)
    public string compensation_quset_Name;              //����(?)(���� ����Ʈ)
}

public class adventure_Manager : MonoBehaviour
{

    public List<Quest_Class> quset_Classes;  //��� ����Ʈ
    public List<Quest_Class> quset_possible; //������ ����Ʈ ���

    //Ŭ�������� �ʾ����� ���� ���� �ȵǴ� �̼�
    private void Awake()
    {

        if(!quset_Classes[0].quest_Clear)
        quset_possible.Add(quset_Classes[0]);

        if (!quset_Classes[1].quest_Clear)
        quset_possible.Add(quset_Classes[1]);


    }





}
