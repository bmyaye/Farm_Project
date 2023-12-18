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

    public bool isSelecting = false;
    public int selectedTool = 0;
    // 1:water 2:fertilizing 3:plot

    public Image[] buttonsImg;
    public Sprite normalButton;
    public Sprite selectedButton;

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
            checkSelection();
        }
        else
        {
            checkSelection();
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "CANCEL";
            //Debug.Log("Selected " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void SelectTool(int toolNumber)
    {
        if (toolNumber == selectedTool)
        {
            //deselect
            checkSelection();
        }
        else
        {
            //select tool number and check to see if anything was also selected
            checkSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonsImg[toolNumber - 1].sprite = selectedButton;
        }
    }

    void checkSelection()
    {
        if (isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "BUY";
                selectPlant = null;
            }
        }
        if (isSelecting)
        {
            if(selectedTool > 0)
            {
                buttonsImg[selectedTool - 1].sprite = normalButton;
            }
            isSelecting = false;
            selectedTool = 0;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyText.text = "$" + money;
    }

}
