using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class skill_UI : MonoBehaviour
{
    public skill thisskill;
    public void setting()
    {
        if(thisskill.Lock)
        this.transform.Find("Lock").gameObject.SetActive(true);
        else
        this.transform.Find("Lock").gameObject.SetActive(false);
        
        this.transform.Find("abilityImg").GetComponent<Image>().sprite = thisskill.img;
        this.transform.Find("name").GetComponent<TextMeshProUGUI>().text = thisskill.name + "Lv.1";
        this.transform.Find("ex").GetComponent<TextMeshProUGUI>().text = thisskill.skillex[thisskill.power_up];
        this.transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("Button").GetComponent<Button>().onClick.AddListener(skillSet_Get);
        this.transform.Find("Button").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Lv.1";
    }
    public void skillSet_Get()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        button.GetComponent<skill_UI>().thisskill.power_up++;
        if (button.GetComponent<skill_UI>().thisskill.power_up == 5)
        {
            button.GetComponent<skill_UI>().thisskill.power_up = 0;
        }

        button.transform.Find("name").GetComponent<TextMeshProUGUI>().text = button.GetComponent<skill_UI>().thisskill.name + "Lv."+ (button.GetComponent<skill_UI>().thisskill.power_up+1);
        button.transform.Find("ex").GetComponent<TextMeshProUGUI>().text = button.GetComponent<skill_UI>().thisskill.skillex[button.GetComponent<skill_UI>().thisskill.power_up];
        button.transform.Find("Button").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Lv."+(button.GetComponent<skill_UI>().thisskill.power_up+1).ToString();




    }
}
