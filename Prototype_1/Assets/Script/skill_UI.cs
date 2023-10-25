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
        if (thisskill.Lock[0])
        this.transform.Find("Lock").gameObject.SetActive(true);
        else
        this.transform.Find("Lock").gameObject.SetActive(false);
        
        this.transform.Find("abilityImg").GetComponent<Image>().sprite = thisskill.img;
        this.transform.Find("name").GetComponent<TextMeshProUGUI>().text = thisskill.name;
        this.transform.Find("ex").GetComponent<TextMeshProUGUI>().text = thisskill.skill_all_ex;
        this.transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("Button").GetComponent<Button>().onClick.AddListener(skillSet_Get);
        this.transform.Find("Button").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "º±≈√";
    }
    public void skillSet_Get()
    {
        GameObject skill_BackGround = GameObject.Find("skill_PowerUPManager").GetComponent<skill_PowerUPManager>().skill_BackGround;

        skill_BackGround.SetActive(true);
        skill_BackGround.transform.Find("Lock").gameObject.SetActive(true);
        if (!thisskill.Lock[1])
            skill_BackGround.transform.Find("Lock").gameObject.SetActive(false);

        for (int i = 0; i< skill_BackGround.transform.Find("Btn").childCount; i++) 
        {
            skill_BackGround.transform.Find("Btn").GetChild(i).name = i.ToString();
            skill_BackGround.transform.Find("Btn").GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            skill_BackGround.transform.Find("Btn").GetChild(i).GetComponent<Button>().onClick.AddListener(skillex);



        }
    }


    public void skillex()
    {

        int num = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameObject back =  EventSystem.current.currentSelectedGameObject.transform.parent.parent.Find("Back").gameObject;
        back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = thisskill.skill_name[num];
        back.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = thisskill.skillex[num];



    }


    

}
