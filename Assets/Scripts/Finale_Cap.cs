using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale_Cap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Textofinal;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            _Textofinal.text = "VICTORIA";
            Invoke("ClearText", 2f);
            Invoke("cambioVictoria", 3f);

            Destroy(GameObject.FindAnyObjectByType<Enemy_Enter>());
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
