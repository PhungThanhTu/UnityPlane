using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Text txtUIStar;
    public Text txtUIDiamond;

    public void Validation(int Star, int Diamond)
    {
        txtUIStar.text = Star.ToString();
        txtUIDiamond.text = Diamond.ToString();
    }
}
