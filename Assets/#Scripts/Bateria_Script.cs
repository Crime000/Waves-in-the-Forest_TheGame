using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bateria_Script : MonoBehaviour
{
    public Light Linterna;
    public GameObject conoVolumetrico;
    public Slider sliderBateria;

    public int Baterias = 0;
    public bool encendida = true;
    public float Energia, EnergiaMaxima, EnergiaTemporal, intensidadLinterna, IntensidadMaxima;
    private float velocidadSlider = 0f;

    // Start is called before the first frame update
    void Start()
    {
        intensidadLinterna = IntensidadMaxima;
        Energia = EnergiaMaxima;
    }

    private void FixedUpdate()
    {

        Energia -= Time.deltaTime;

        intensidadLinterna = 4 * Energia / EnergiaMaxima * 2f;

        if(intensidadLinterna > IntensidadMaxima)
        {
            intensidadLinterna = 4;
        }
        if (encendida)
        {
            Linterna.intensity = intensidadLinterna;
            float energiaActual = Mathf.SmoothDamp(sliderBateria.value, Energia, ref velocidadSlider, 20 * Time.deltaTime);
            sliderBateria.value = energiaActual;
        }

    }

    public void CambioDeEstado()
    {
        EncenderApagar();
        encendida = !encendida;
    }

    private void EncenderApagar()
    {
        if (encendida)
        {
            EnergiaTemporal += Energia;
            Linterna.intensity = 0f;
            conoVolumetrico.SetActive(false);
        }
        if(encendida == false)
        {
            Energia = EnergiaTemporal;
            EnergiaTemporal = 0f;
            conoVolumetrico.SetActive(true);
        }
        
    }
}
