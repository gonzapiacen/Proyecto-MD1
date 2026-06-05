using System;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] int _itemCount = 0;
    [SerializeField] TextMeshProUGUI _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    //Trigger de Reliquias para completar el juego (Desarrollo) -Cris-
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Reliquia"))
        {
            Destroy(collision.gameObject);
            _itemCount++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        _text.text = "Reliquias: " + _itemCount;
    }

    public int GetItemCount()
    {
        return _itemCount;
    }
}
