using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDateUI : MonoBehaviour
{
    public quest_list quest_list;
    public datalist datalist;
    public InputField idd;
    public InputField tiendo;
    public Button capnhat;
    public void UpDAteUI_capnhat()
    {
        capnhat.onClick.AddListener(() => OnCapnhatClick());
    }
    public void OnCapnhatClick()
    {
        int a = int.Parse(idd.text);
        foreach (var data in quest_list.dataquestslist)
        {
            if (data.id == a)
            {
                data.tiendo_txt = tiendo.text;
            }
        }
        datalist.save();
        //FindObjectOfType<view_quest>().CapNhatGiaoDien();
        FindObjectOfType<view_quest>().CapNhatGiaoDien(a);
    }


}

