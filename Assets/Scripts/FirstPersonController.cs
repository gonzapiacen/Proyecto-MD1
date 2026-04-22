using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Transform _handSlot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //rotacion del personaje respecto a la camara, usa Slerp para dar peso al movimiento
        Quaternion yRotation = Quaternion.Euler(transform.eulerAngles.x,_camera.eulerAngles.y,transform.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, yRotation, Time.deltaTime * 5);

        //rotacion del objeto en mano junto con la camara
        _handSlot.rotation = Quaternion.Slerp(_handSlot.rotation,_camera.rotation,Time.deltaTime * 5);
    }
}
