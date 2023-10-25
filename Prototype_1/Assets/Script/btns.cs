using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class btns : MonoBehaviour
{
    GameObject btns_;

    public GameObject office, Lab, board,adventure,skill_Ex;
    private void Awake()
    {
        btns_ = GameObject.Find("btns");

    }
    public void skillBackOff()
    {
        skill_Ex.SetActive(false);
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
