using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    [Header("All Camera")]
    public GameObject[] listCamera;
    bool change_;

    public void gantiKamera()
    {
        if (!change_)
        {
            listCamera[0].SetActive(true);
            listCamera[1].SetActive(false);
            change_ = true;
        }
        else
        {
            listCamera[1].SetActive(true);
            listCamera[0].SetActive(false);
            change_ = false;
        }
            
    }
}
