using UnityEngine;

public class PausePanelDeactivator : MonoBehaviour
{
    public void OnClose()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
