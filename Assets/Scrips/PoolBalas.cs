using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    [SerializeField] private GameObject Bala;
    [SerializeField] private Arma InfoArma;
    [SerializeField] private int CantidadBalas;
    [SerializeField] private List<GameObject> LisBalas;
    private Transform Contenedor;
    void Start()
    {
        Contenedor = GameObject.FindGameObjectWithTag("ConteBalas")?.transform;
        addbala(CantidadBalas);
    }
    private void addbala(int can)
    {
        for (int i = 0; i < can; i++)
        {
            GameObject B = Instantiate(Bala);
            LisBalas.Add(B);
            B.transform.parent = Contenedor;
            B.GetComponent<Bala>().RecibirDatos(InfoArma);
        }
    }
    public GameObject ReturnBala()
    {
        for (int i = 0; i < LisBalas.Count; i++)
        {
            if (!LisBalas[i].activeSelf)
            {
                return LisBalas[i];
            }
        }
        addbala(1);
        return LisBalas[LisBalas.Count - 1];
    }
}
