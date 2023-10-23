using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_PowerUPManager : MonoBehaviour
{
    public GameObject Background, SkillUI;
    public List<skill_UI> buttons;

    private void Awake()
    {
        for(int i =0; i<SkillManager.SkillManagerthis.skill_list.Count; i++)
        {
            Instantiate(SkillUI, Background.transform);
            buttons.Add(Background.transform.GetChild(i).gameObject.GetComponent<skill_UI>());

            buttons[i].thisskill = SkillManager.SkillManagerthis.skill_list[i];
            buttons[i].setting();

        }
    }


}
