using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class abilityUI : MonoBehaviour
{
    public ability ability;

    public void setting()
    {
        this.transform.Find("abilityImg").GetComponent<Image>().sprite = ability.img;
        this.transform.Find("name").GetComponent<TextMeshProUGUI>().text = ability.name;
        this.transform.Find("ex").GetComponent<TextMeshProUGUI>().text = ability.ex;
        this.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Image>().fillAmount = ability.powerup/ 5;
        this.transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("Button").GetComponent<Button>().onClick.AddListener((ability.stats.Invoke));
    }


}
