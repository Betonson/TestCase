using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelDeactivator : MonoBehaviour
{
    public void OnClose()
    {
        gameObject.SetActive(false); ;
    }
}
