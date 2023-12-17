using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 100;
    public Text moneyText;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            //Debug.Log("Deselected " + selectPlant.plant.plantName);
            selectPlant.btnImage.color = buyColor;
            selectPlant.btnTxt.text = "BUY";
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            if(selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "BUY";
            }
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "CANCEL";
            //Debug.Log("Selected " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyText.text = "$" + money;
    }

}
