using UnityEngine;

public class ZoneSafe : MonoBehaviour
{
    public PlayerMovement player;
    public bool ZoneSafeBool;

    private void OnTriggerStay(Collider collider) 
    {
        if(collider.CompareTag("Player"))
        {
            ZoneSafeBool = player.playerissafe = true;
            Debug.Log("ZONA SEGURA");
        }   
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            ZoneSafeBool = player.playerissafe = false;
            Debug.Log("ZONA PELIGROSA");
        }
    }

    public bool GetZoneSafeBool()
    {
        return ZoneSafeBool;
    }

}
