using UnityEngine;

public class PlayerMovementILO : MonoBehaviour
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


        //esto antes estaba en if(Input.GetKeyDown(...)) dejenlo en GetKey solo, porque el GetKeyDown toma solo cuando se toca la tecla, no cundo se mantiene apretada.
        if (Input.GetKey(KeyCode.LeftShift))
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

        // float magnitude = movePlayer.magnitude;
        
        // se declara una variable que no se usa, la dejo asi para no eliminarla por las dudas.

        transform.Translate(movePlayer * SpeedMovement * Time.deltaTime);

       
    }
}
