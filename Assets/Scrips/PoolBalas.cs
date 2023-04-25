using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    [SerializeField] private GameObject Bala;
    [SerializeField] private int CantidadBalas;
    [SerializeField] private List<GameObject> LisBalas;
    [SerializeField] Transform Contenedor;
    void Start()
    {
        addbala(CantidadBalas);
    }
    private void addbala(int can)
    {
        for (int i = 0; i < can; i++)
        {
            GameObject B = Instantiate(Bala);
            LisBalas.Add(B);
            B.transform.parent = Contenedor;
            B.transform.localPosition = new Vector3(0.089f,0,0);
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
