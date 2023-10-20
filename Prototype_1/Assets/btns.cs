using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btns : MonoBehaviour
{
    GameObject btns_;

    public GameObject office, Lab, board;
    private void Awake()
    {
        btns_ = GameObject.Find("btns");

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
        // board.SetActive(false);
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
}
