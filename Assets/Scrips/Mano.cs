using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public static Mano Instancia;
    public int Valor;
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
}
