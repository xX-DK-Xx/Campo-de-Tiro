using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlEstadisticas : MonoBehaviour
{
    [Header("Datos Campo")]
    [SerializeField] Text PreTex;
    [Header("Datos Generales")]
    [SerializeField] Text PreGTex;
    [SerializeField] Text ImpactosTex;
    [SerializeField] Text FallosTex;
    [SerializeField] Text DisparosTex;
    public static ControlEstadisticas Instancia;
    float Precicion, PreTotal;
    int ImpactosTotales, DisparosTotales,ImpactosAcertados,DisparosEchos,Fallos;
    private void Awake()
    {
        if (Instancia==null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Impacto(bool Tiro)
    {
        Debug.Log(Tiro);
        DisparosEchos++;
        DisparosTotales++;
        DisparosTex.text = "DISPAROS ECHOS: "+ DisparosTotales;
        if (Tiro)
        {
            ImpactosAcertados++;
            ImpactosTotales++;
            ImpactosTex.text ="DISPAROS ACERTADOS: "+ImpactosTotales;
        }
        else
        {
            Fallos++;
            FallosTex.text = "DISPAROS FALLADOS: "+Fallos;
        }
        PreTex.text = "PRECICION: " + (float)(ImpactosAcertados / DisparosEchos)*100 + "%";
        PreGTex.text = "PRECICION: " + (float)(ImpactosTotales / DisparosTotales)*100 + "%";
    }
    public void Restablecer()
    {
        PreTex.text = "PRECICION: 0%";
        ImpactosAcertados = 0;
        DisparosEchos = 0;
    }
}
