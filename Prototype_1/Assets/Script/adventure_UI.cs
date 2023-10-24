using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventure_UI : MonoBehaviour
{

    public GameObject QC_UI,background;
    private void OnEnable()
    {
        for(int i = 0; i< background.transform.childCount; i++)
        {
            Destroy(background.transform.GetChild(i).gameObject);
        }
        foreach (Quest_Class QC in ReadyManager.readyManagerthis.adventure_Manager.quset_possible)
        {
            GameObject QC_UI_prefab = Instantiate(QC_UI, background.transform);
            QC_UI_prefab.GetComponent<Quest_UI>().thisQuest = QC;

            foreach (Quest_Class HQ in ReadyManager.readyManagerthis.have_quest)
            {
                if (QC.quest_Name.Equals(HQ.quest_Name))
                {
                    HQ.quest_Clear = QC.quest_Clear;

                }
            }

            QC_UI_prefab.GetComponent<Quest_UI>().Setting();



        }
       






    }
   
}
