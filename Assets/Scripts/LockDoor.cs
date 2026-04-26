using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LockDoor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] ItemCollector _itemCollector;
    private bool _inside = false;

    void Start()
    {
        ClearText();
    }

    void Update()
    {
        if (_inside && Input.GetKeyDown(KeyCode.E))
        {
            if(_itemCollector.GetItemCount() < 3)
            {
                _text.text = "Necesito 3 reliquias";
                Invoke("ClearText", 2f);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            _text.text = "E";
            _inside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        ClearText();
        _inside = false;
    }

    private void ClearText()
    {
        _text.text = "";
    }


}
