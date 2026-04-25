using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Transform _camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //rotacion del personaje respecto a la camara
        Quaternion yRotation = Quaternion.Euler(transform.eulerAngles.x,_camera.eulerAngles.y,transform.eulerAngles.z);
        transform.rotation = yRotation;

    }
}
