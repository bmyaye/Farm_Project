using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text nameText;
    public Text priceText;
    public Image icon;

    public Image btnImage;
    public Text btnTxt;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
        fm.SelectPlant(this);
    }

    //public void SellPlant()
    //{
    //    Debug.Log("Sold " + plant.plantName);
    //    fm.SelectPlant(this);
    //}

    void InitializeUI()
    {
        nameText.text = plant.plantName;
        priceText.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

}
