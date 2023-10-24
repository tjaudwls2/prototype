using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
[System.Serializable]
public class ability
{
    public string name;
    public string ex;
    public Sprite img;
    public float powerup;
    public UnityEvent stats;
}

public class ability_PowerUPManager : MonoBehaviour
{
    public Character dumb;

    public GameObject Background,abilityUI;
    public List<abilityUI> buttons;
    public List<ability> Ability;

    private void Start()
    {
        dumb = ReadyManager.readyManagerthis.stat_Save_dumb;
        for (int i = 0; i < Ability.Count; i++)
        {
            Instantiate(abilityUI, Background.transform);
            buttons.Add(Background.transform.GetChild(i).gameObject.GetComponent<abilityUI>());
            buttons[i].ability = Ability[i];
            buttons[i].setting();
   
        }

    }


    public void attack_plus()
    {

        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup < 5)
        {
            dumb.attack_Power += 5;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup++;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().setting();
        }
    }
    public void attack_Speed_plus()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup < 5)
        {
            dumb.attack_Speed -= 1f;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup++;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().setting();
        }
    
    }
    public void maxhp_plus()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup < 5)
        {
            dumb.hp += 50;
            dumb.maxhp += 50;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup++;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().setting();
        }
     
    }
    public void speed_plus()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup < 5)
        {
            dumb.speed += 10;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup++;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().setting();
        }
  
    }
 
    public void defense_plus()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup < 5)
        {
            dumb.defense += 5f;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().ability.powerup++;
            EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<abilityUI>().setting();
        }
      
    }

}
