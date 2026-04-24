using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] float _range = 5;
    [SerializeField] float _cd = 0;
    private float _chargeTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

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
            }
        }
        else
        {
            _cd -= Time.deltaTime;
        }

    }

    private void Stun()
    {
        if (_chargeTime < 3)
        {
            _chargeTime += Time.deltaTime;
            //Debug.Log(_chargeTime);
        }
        else
        {
            //Genera una RayCast desde el centro de la camara hacia adelante
            Debug.DrawRay(_camera.position, _camera.forward * 5f, Color.red, 2f);
            RaycastHit target;
            if (Physics.Raycast(_camera.position, _camera.forward * 5f, out target, _range))
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
}
