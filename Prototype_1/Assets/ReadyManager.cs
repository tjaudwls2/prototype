using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class team
{
    public GameObject partner; // ������ ����
    public skill[] partner_skill; //��Ʈ�ʽ�ų
}

public class ReadyManager : MonoBehaviour
{
    private static ReadyManager readyManager = null;
    void Awake()
    {
        if (null == readyManager)
        {
            readyManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }




    }
    public static ReadyManager readyManagerthis
    {
        get
        {
            if (null == readyManager)
            {
                return null;
            }
            return readyManager;
        }
    }
    public team[] myteam;


    




}
