using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    protected Rigidbody rb;
    protected Arma Info;
    protected int Penetraciones;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void OnEnable()
    {
        rb.AddRelativeForce(new Vector3(-Info.VelocidadP, 0,0));
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Entorno")
        {
            apa();
        }
        if (collision.tag == "enemy")
        {
            //collision.GetComponent<Enemigo>().dama(CalcularDaño());
            if (Penetraciones == 0)
            {
                apa();
            }
            else
            {
                Penetraciones--;
            }
        }
    }
    protected void apa()
    {
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    public void RecibirDatos(Arma info)
    {
        Info = info;
    }
}
