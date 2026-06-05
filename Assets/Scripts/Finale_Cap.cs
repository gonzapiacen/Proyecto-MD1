using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale_Cap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Textofinal;
    [SerializeField] private GameObject EnteDead;
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
        SceneManager.LoadScene(3);
    }

    private void ClearText()
    {
        _Textofinal.text = "";
    }
}
