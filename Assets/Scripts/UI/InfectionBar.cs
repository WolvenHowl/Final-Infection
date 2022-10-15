using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour
{
    public Slider InfectionSilder;
    
    private void Start() 
    {
        //InfectionSilder = gameObject.GetComponent<Slider>();
    }

    public void SetMaxSlider(int infection)
    {
        InfectionSilder.maxValue = infection;
        //InfectionSilder.value = infection;
    }

    public void SetSlider(int infection)
    {
        InfectionSilder.value = infection;
    }
}
