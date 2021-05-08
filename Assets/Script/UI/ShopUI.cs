using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public PlayerData plrdata;
    public Text txtStar;
    public Text txtDiamond;


    public void Validation()
    {
        txtDiamond.text = plrdata.Diamond.ToString();
        txtStar.text = plrdata.Star.ToString();

    }
}
