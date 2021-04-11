using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider ;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxValue(int maxVal)
    {
        slider.maxValue = maxVal;
        slider.value = maxVal;

    }

    public void SetValue (int value)
    {
        slider.value = value;

    }
 
}
