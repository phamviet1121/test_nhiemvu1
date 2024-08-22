using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class click_btn : MonoBehaviour
{
    public quest_list quest_list;
    public datalist datalist;


    public Button cick_button;
    public Text click_button_txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void Click()
    {
        click_button_txt.text = "da nhan";
        cick_button.interactable = false;
        Debug.Log($"{click_button_txt.text}");
    } 
    //public void UpdateButtonState(int id)
    //{
    //    Debug.Log("da chay ham click btn");
    //    foreach (var data in quest_list.dataquestslist)
    //    {
    //        if (data.id == id)
    //        {
    //            data.trangthai_btn = false;
    //            data.trangthai_txt = click_button_txt.text;

    //        }

    //    }
    //    datalist.save();
    //    //FindObjectOfType<view_quest>().CapNhatGiaoDien();
    //    FindObjectOfType<view_quest>().CapNhatGiaoDien(id);
    //}
}
