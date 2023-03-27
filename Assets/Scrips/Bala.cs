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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blanco")
        {
            ControlEstadisticas.Instancia?.Impacto(true);
            Debug.Log(1);
            apa();
        }
        if (other.tag == "Entorno")
        {
            ControlEstadisticas.Instancia?.Impacto(false);
            apa();
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
