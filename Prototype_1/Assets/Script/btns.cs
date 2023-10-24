using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class btns : MonoBehaviour
{
    GameObject btns_;

    public GameObject office, Lab, board,adventure;
    private void Awake()
    {
        btns_ = GameObject.Find("btns");

    }
    public void skillBackOff()
    {
        GameObject skill_BackGround = GameObject.Find("skill_PowerUPManager").GetComponent<skill_PowerUPManager>().skill_BackGround;

        skill_BackGround.SetActive(false);
    }
    public void offbtn()
    {
        btns_.SetActive(false);
    }
    public void onbtn()
    {
        btns_.SetActive(true);

        office.SetActive(false);
        Lab.SetActive(false);
        adventure.SetActive(false);
        // board.SetActive(false);
    }
    public void adventureOn()
    {
        adventure.SetActive(true);
    }
    public void officeOn()
    {
        office.SetActive(true);
    }
    public void LabOn()
    {
        Lab.SetActive(true);
    }
    public void boardOn()
    {
        board.SetActive(true);
    }
    public void nextscean()
    {
        SceneManager.LoadScene(1);

    }
}
