using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public static Mano Instancia;
    public int Valor,ManoActiva=1;
    private void Awake()
    {
        Mano.Instancia = this;
    }
    public void ManoDerecha()
    {
        Valor = 1;
    }
    public void ManoIzquierda()
    {
        Valor = 0;
    }
    public void ActivarMano(int valor)
    {
        ManoActiva = valor;
    }
}
