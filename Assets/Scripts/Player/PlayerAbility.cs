using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] float _range = 5;
    [SerializeField] float _cd = 0;
    [SerializeField] Light _flashlight;
    private float _chargeTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (_cd <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Stun();
            }
            else
            {
                _chargeTime = 0;
                ResetFlashlight();
            }
        }
        else
        {
            _cd -= Time.deltaTime;
            ResetFlashlight();
        }

    }

    private void Stun()
    {
        if (_chargeTime < 3)
        {
            _chargeTime += Time.deltaTime;
            FocusFlashlight();
            Debug.Log(_chargeTime);
        }
        else
        {
            //Genera una RayCast desde el centro de la camara hacia adelante
            Debug.DrawRay(_camera.position, _camera.forward * 5f, Color.red, 2f);
            RaycastHit target;
            if (Physics.Raycast(_camera.position, _camera.forward, out target, _range))
            {
                if (target.collider.CompareTag("Enemy"))
                {
                    //Debug.Log("Enemy stun");
                    target.collider.GetComponent<Enemy_Enter>().GetStun();
                }
            }
            _chargeTime = 0;
            _cd = 3;
        }
    }

    private void FocusFlashlight()
    {
        _flashlight.spotAngle = Mathf.Lerp(_flashlight.spotAngle, 40f, Time.deltaTime); // Enfoca el az
        _flashlight.innerSpotAngle = Mathf.Lerp(_flashlight.innerSpotAngle, 30f,Time.deltaTime);
        _flashlight.intensity = Mathf.Lerp(_flashlight.intensity, 20f, Time.deltaTime); // Aumenta el brillo
    }

    private void ResetFlashlight()
    {
        _flashlight.spotAngle = Mathf.Lerp(_flashlight.spotAngle, 120f,Time.deltaTime); // Desenfoca el haz
        _flashlight.innerSpotAngle = Mathf.Lerp(_flashlight.innerSpotAngle, 60f,Time.deltaTime);
        _flashlight.intensity = Mathf.Lerp(_flashlight.intensity, 5f, Time.deltaTime); // Disminuye el brillo
    }
}
