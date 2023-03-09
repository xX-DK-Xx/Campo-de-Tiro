using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] protected GameObject PuntoSalida;
    [SerializeField] protected ParticleSystem Destello;
    [SerializeField] protected AudioClip SonidoDisparo;
    [Header("Carga")]
    [SerializeField] protected int BalasCargador;
    [SerializeField] protected float TiempoRecarga;
    [Header("Bala")]
    [SerializeField] protected int Daño;
    [SerializeField] protected int Velocidad;
    [SerializeField] protected float Rango;
    [Header("Disparo")]
    [SerializeField] protected float ratefire;
    public int DañoP { get { return Daño; } }
    public int VelocidadP { get { return Velocidad; } }
    public float RangoP { get { return Rango; } }
    protected int MunicionActual;
    protected float DispercionAcumulada;
    protected bool PuedeDisparas = true, PuedeREcargar = true;
    protected PoolBalas Pool;
    protected Coroutine RutinaDispercion;
    protected void Awake()
    {
        MunicionActual = BalasCargador;
        Pool = GetComponent<PoolBalas>();
    }
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && PuedeREcargar)
        {
            if (MunicionActual != BalasCargador)
            {
                PuedeREcargar = false;
                StartCoroutine(TienpoRecargar());
            }
        }
    }
    protected void Disparar()
    {
        if (PuedeDisparas == true && MunicionActual > 0 && Time.deltaTime != 0)
        {
            MunicionActual--;
            //controllersounds.instanse?.ponersonido(SonidoDisparo);
            InstanciarBala();
        }
    }
    protected virtual void InstanciarBala()
    {
        GameObject bala = Pool.ReturnBala();
        bala.transform.position = PuntoSalida.transform.position;
        bala.transform.localRotation = transform.localRotation;
        bala.SetActive(true);
        PuedeDisparas = false;
        StartCoroutine("Cadencia");
    }
    protected void Recargar()
    {
        MunicionActual = BalasCargador;
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
        //Destello.Play();
        yield return new WaitForSeconds(ratefire);
        PuedeDisparas = true;
    }
}
