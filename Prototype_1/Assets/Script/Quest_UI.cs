using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest_UI : MonoBehaviour
{
    public Quest_Class thisQuest;

    public void Setting()
    {
        this.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = thisQuest.quest_Name;
        this.transform.Find("Ex").GetComponent<TextMeshProUGUI>().text = thisQuest.quest_Ex;
        this.transform.Find("Btn").GetComponent<Button>().interactable = true;
        if (thisQuest.quest_accept&&!thisQuest.quest_Clear)
        {
            this.transform.Find("Btn").GetComponent<Button>().interactable = false;
        }
        if (!thisQuest.quest_Clear)
            this.transform.Find("Btn").GetChild(0).GetComponent<TextMeshProUGUI>().text = thisQuest.quest_accept ? "진행중" : "수락";
        else
            this.transform.Find("Btn").GetChild(0).GetComponent<TextMeshProUGUI>().text = "보상";


            this.transform.Find("Btn").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("Btn").GetComponent<Button>().onClick.AddListener(Accept);



    }

    public void Accept()
    {
        if (!thisQuest.quest_Clear)
        {
            thisQuest.quest_accept = true;
            ReadyManager.readyManagerthis.have_quest.Add(thisQuest);
            Setting();
        }
        else //완료시
        {
            ReadyManager.readyManagerthis.Gold += thisQuest.compensation_Gold;

            foreach (Quest_Class QC in ReadyManager.readyManagerthis.adventure_Manager.quset_Classes)
            {
                if(QC.quest_Name == thisQuest.compensation_quset_Name)
                {
                    ReadyManager.readyManagerthis.adventure_Manager.quset_possible.Add(QC);
                }


            }
          //  SkillManager.SkillManagerthis.



        }




    }



}
