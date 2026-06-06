using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale_Cap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Textofinal;
    [SerializeField] private GameObject EnteDead;
    [SerializeField] SnapshotController sc;
    public bool PlayerWin = false;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            _Textofinal.text = "VICTORIA";
            Invoke("ClearText", 2f);
            Invoke("cambioVictoria", 3f);

            Destroy(EnteDead);
            PlayerWin = true;
        }
    }

    private void cambioVictoria()
    {
        sc.enabled = false;
        SceneManager.LoadScene(4);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void ClearText()
    {
        _Textofinal.text = "";
    }
}
