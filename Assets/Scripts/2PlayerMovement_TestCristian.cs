using UnityEngine;

public class PlayerMovementTEST2 : MonoBehaviour
{
    private float SpeedMovement;
    [SerializeField] private float FastSpeed;
    [SerializeField] private float NormalSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpeedMovement = NormalSpeed;
        

    }

    // Update is called once per frame
    void Update()
    {

        ConfigMoventPlayer();


    }

    public void ConfigMoventPlayer() //FUNCION PARA MOVIMIENTO DEL PLAYER
    {
        //Notas: Faltaria agregar para que no/evitar caiga de lados, por el momento lo hice con el inspector
        //con X Y Z para evitar eso.

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpeedMovement = FastSpeed;
        }
        else
        {
            SpeedMovement = NormalSpeed;
        }


        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        
        Vector3 movePlayer = new Vector3(HorizontalInput, 0, VerticalInput);

        float magnitude = movePlayer.magnitude;

        transform.Translate(movePlayer * SpeedMovement * Time.deltaTime);

       
    }
}

//Prueba de guardado
//Prueba de rama
//Prueba Ilo
//Prueba ILO2
//Prueba branch