using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health = 3;
    [SerializeField] TextMeshProUGUI _text;

    void Awake()
    {
        _text.text = "Salud: 3";
    }
    public void SetHealth(int dmg)
    {
        _health -= dmg;
        _text.text = "Salud: "+_health;
        if(_health <= 0)
        {
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
