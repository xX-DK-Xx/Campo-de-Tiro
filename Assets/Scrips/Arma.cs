using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] protected GameObject PuntoSalida;
    [SerializeField] protected ParticleSystem Destello;
    [SerializeField] protected AudioSource Sonido;
    [SerializeField] protected PoolBalas Impactos;
    [SerializeField] protected Text TexBalas;
    [Header("Carga")]
    [SerializeField] protected int BalasCargador;
    [SerializeField] protected float TiempoRecarga;
    [Header("Disparo")]
    [SerializeField] protected float ratefire;
    [SerializeField] protected LayerMask LM;
    protected int MunicionActual;
    protected float DispercionAcumulada;
    protected bool PuedeDisparas = true, PuedeREcargar = true;
    protected Coroutine RutinaDispercion;

    private void Start()
    {
        MunicionActual = BalasCargador;
    }
    public void Disparar(InputAction.CallbackContext Ac)
    {
        if (this.enabled)
        {
            if (Ac.performed && PuedeDisparas == true && MunicionActual > 0 && Time.deltaTime != 0)
            {
                MunicionActual--;
                TexBalas.text = MunicionActual+"/"+BalasCargador;
                Sonido?.Play();
                InstanciarBala();
            }
        }
    }
    public void IntentarRecarga(InputAction.CallbackContext Ac)
    {
        if (MunicionActual != BalasCargador && PuedeREcargar && Ac.performed)
        {
            PuedeREcargar = false;
            StartCoroutine(TienpoRecargar());
        }
    }
    public void VerBalas(InputAction.CallbackContext Ac)
    {
        if (Ac.performed)
        {
            TexBalas.gameObject.SetActive(true);
        }
        else
        {
            TexBalas.gameObject.SetActive(false);
        }
    }
    protected virtual void InstanciarBala()
    {
        PuedeDisparas = false;
        RaycastHit Impacto;   
        if (Physics.Raycast(PuntoSalida.transform.position, PuntoSalida.transform.forward, out Impacto, 100,LM))
        {
            ControlEstadisticas.Instancia?.Impacto(true);
            GameObject Imp = Impactos.ReturnBala();
            Imp.transform.position = new Vector3(Imp.transform.position.x,Impacto.point.y, Impacto.point.z);
            Imp.SetActive(true);
        }
        else
        {
            ControlEstadisticas.Instancia?.Impacto(false);
        }
        StartCoroutine("Cadencia");
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(PuntoSalida.transform.position, PuntoSalida.transform.forward);
    }
    protected void Recargar()
    {
        MunicionActual = BalasCargador;
        TexBalas.text = MunicionActual + "/" + BalasCargador;
    }
    public void ActivarArma()
    {
        PuedeDisparas = true;
        PuedeREcargar = true;
        StopAllCoroutines();
    }
    protected IEnumerator TienpoRecargar()
    {
        PuedeDisparas = false;
        yield return new WaitForSeconds(TiempoRecarga);
        Recargar();
        PuedeDisparas = true;
        PuedeREcargar = true;
    }
    protected IEnumerator Cadencia()
    {
        Destello.Play();
        yield return new WaitForSeconds(ratefire);
        PuedeDisparas = true;
    }
}
