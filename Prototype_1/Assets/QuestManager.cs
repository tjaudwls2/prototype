using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
   
    public void Quest_Check(float time = 0, GameObject enemy = null)
    {
        foreach (Quest_Class QC in ReadyManager.readyManagerthis.have_quest)
        {
            Quest_Set(QC, time, enemy);
        }
    }
    public void Quest_Set(Quest_Class QC, float time = 0 ,GameObject enemy=null)
    {
        switch (QC.quest_Type)
        {
            case Quest_type.버티기:

               if(time >= QC.Count_Time)
               QC.quest_Clear = true;
                 
                



                break;
            case Quest_type.잡기:
                if (enemy != null)
                {
                    string[] names = enemy.name.Split("(");

                    if (names[0] == QC.enemy_Quset.Enemy.name)
                    {
                        QC.enemy_Quset.Count_Enemy++;
                        if (QC.enemy_Quset.Count_Enemy >= QC.enemy_Quset.Max_Enemy)
                        {
                            QC.quest_Clear = true;
                        }
                    }
                }
                break;
        }
    }
 
}
