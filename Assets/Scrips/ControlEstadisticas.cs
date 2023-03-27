using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEstadisticas : MonoBehaviour
{
    [SerializeField] float Precicion;
    [SerializeField] int ImpactosFallados,ImpactosAcertados,DisparosEchos;
    public static ControlEstadisticas Instancia;
    public void Impacto(bool Tiro)
    {
        DisparosEchos++;
        ImpactosAcertados += Tiro == true ? 1 : 0;
        ImpactosFallados += Tiro == false ? 1 : 0;
        Precicion = ImpactosAcertados / DisparosEchos;
    }
}
