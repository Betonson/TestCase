using UnityEngine;

public class PausePanelDeactivator : MonoBehaviour
{
    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
