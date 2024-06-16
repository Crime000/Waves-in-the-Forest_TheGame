using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesGenerales : MonoBehaviour
{

    public Light luzCocina;
    public Light luzSalon;
    public Light luzComedor;

    public bool cocina, salon, comedor;

    // Start is called before the first frame update
    void Start()
    {
        cocina = true;
        salon = true;
        comedor = true;
    }

    void Update()
    {
        ApagarLuces();
    }

    public void ApagarLuces()
    {
        if(cocina == false)
        {
            luzCocina.intensity = 0f;
        }
        if(salon == false)
        {
            luzSalon.intensity = 0f;
        }
        if (comedor == false)
        {
            luzComedor.intensity = 0f;
        }
    }
}
