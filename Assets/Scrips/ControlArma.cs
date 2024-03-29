using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArma : MonoBehaviour
{
    [SerializeField] Arma pistola;
    [SerializeField] GameObject Modelo,Modelo2;
    [SerializeField] GameObject ManoDere;
    [SerializeField] GameObject ManoIzq;
    public void PrenderArma()
    {
        if (!pistola.enabled)
        {
            if (Mano.Instancia.Valor == 1)
            {
                Modelo.SetActive(false);
                pistola.transform.SetParent(ManoDere.transform);
                Mano.Instancia.ActivarMano(1);
            }
            else
            {
                Modelo2.SetActive(false);
                pistola.transform.SetParent(ManoIzq.transform);
                Mano.Instancia.ActivarMano(0);
            }
            pistola.enabled = true;
            pistola.transform.localPosition = Vector3.zero;
            pistola.transform.localRotation = Quaternion.Euler(-90, 90, 0);
        }
    }
    public void ApagarArma()
    {
        pistola.enabled = false;
        Modelo.SetActive(true);
        Modelo2.SetActive(true);
        pistola.transform.SetParent(null);
    }
}
