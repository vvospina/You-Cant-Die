using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } } 
    private int puntosTotales;
    
    public void SumarPuntos (int puntosObtenidos)
    {
        puntosTotales += puntosObtenidos;

    }
}
