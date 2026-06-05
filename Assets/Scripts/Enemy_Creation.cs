using UnityEngine;

public class Enemy_Creation : MonoBehaviour
{
    //Invocacion del enemigo en el final.

    [SerializeField] private GameObject prefabEnemigo;
    [SerializeField] private Transform puntodSpawn;

    public AudioSource audioSourceEnemy;

    public bool EnemigoReady = false;
    public float RetrasoCreacion = 1.3f;

    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player") && EnemigoReady == false)
        {
            EnemigoReady = true;
            Invoke("CreacionEnemigo", RetrasoCreacion);
            

        }
    }

    void CreacionEnemigo()
    {
        //GameObject nuevoEnemigo = Instantiate(prefabEnemigo, puntodSpawn.position, puntodSpawn.rotation);
        prefabEnemigo.SetActive(true);
        audioSourceEnemy.Play();
    }


}
