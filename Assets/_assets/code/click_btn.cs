using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class click_btn : MonoBehaviour
{
    public quest_list quest_list;
    public datalist datalist;
    int a;
    public Text thongtin_txtt;
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

        saveUPload();
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

    public void saveUPload()
    {
        Debug.Log("da chay nut button");
        foreach (var savedata in quest_list.dataquestslist)
        {
           
            if (savedata.thongtin_txt == thongtin_txtt.text)
            {
                a = savedata.id;
                savedata.trangthai_txt = click_button_txt.text;
                Debug.Log($"{savedata.id}");
                savedata.trangthai_btn = false;
            }
        }
        Debug.Log($"{a}");
        datalist.save();
        //FindObjectOfType<view_quest>().CapNhatGiaoDien();
        FindObjectOfType<view_quest>().CapNhatGiaoDien(a);
    }
}
