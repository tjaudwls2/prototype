using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class team
{
    public GameObject partner; // 데려갈 동료
    public skill[] partner_skill; //파트너스킬
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
