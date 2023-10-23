using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventure_UI : MonoBehaviour
{

    public GameObject QC_UI,background;
    public void Start()
    {
        foreach (Quest_Class QC in ReadyManager.readyManagerthis.adventure_Manager.quset_possible)
        {
            GameObject QC_UI_prefab =  Instantiate(QC_UI, background.transform);
            QC_UI_prefab.GetComponent<Quest_UI>().thisQuest = QC;
            QC_UI_prefab.GetComponent<Quest_UI>().Setting();

        }


    }
}
