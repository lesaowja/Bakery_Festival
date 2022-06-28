using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;
public class MiniGameUiMng : MonoBehaviour
{
    // Start is called before the first frame update
    string Name;
    string Gold;
    string ruby;
    string perGold;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI RubyText;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI  PerGoldText;


    void Start()
    {
        Name = PlayerPrefs.GetString("Name");
        Gold = PlayerPrefs.GetString("Gold");
        ruby = PlayerPrefs.GetString("Ruby");
        perGold = PlayerPrefs.GetString("_goldPerSec");

        NameText.text = Name;
        GoldText.text = Gold;
        RubyText.text = ruby;
        PerGoldText.text = perGold; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStartBut()
    {
        int DropFoodsStart = 0;
        DropFoodsStart = 1;
        PlayerPrefs.SetInt("DropFoodsStart",DropFoodsStart);
    }
}
