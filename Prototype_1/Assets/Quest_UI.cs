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
        if (thisQuest.quest_accept)
        {
            this.transform.Find("Btn").GetComponent<Button>().interactable = false;
        }
        this.transform.Find("Btn").GetChild(0).GetComponent<TextMeshProUGUI>().text = thisQuest.quest_accept ? "진행중" : "수락";
        this.transform.Find("Btn").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("Btn").GetComponent<Button>().onClick.AddListener(Accept);



    }

    public void Accept()
    {
        thisQuest.quest_accept = true;
        ReadyManager.readyManagerthis.have_quest.Add(thisQuest);
        Setting();





    }



}
