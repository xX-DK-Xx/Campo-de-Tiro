using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArma : MonoBehaviour
{
    [SerializeField] Arma pistola;
    [SerializeField] GameObject Modelo;
    [SerializeField] GameObject Rayo;
    [SerializeField] GameObject Colicion;
    public void PrenderArma()
    {
        pistola.enabled = true;
        Modelo.SetActive(false);
        pistola.transform.SetParent(Colicion.transform);
        pistola.transform.localPosition = Vector3.zero;
        pistola.transform.localRotation = Quaternion.Euler(-90,90,0);
    }
    public void ApagarArma()
    {
        pistola.enabled = false;
        Modelo.SetActive(true);
        pistola.transform.SetParent(null);
    }
}
