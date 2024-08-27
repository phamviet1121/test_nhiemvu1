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
                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    if (data.trangthai_txt != "da nhan")
                    {
                        data.trangthai_btn = true;
                        data.trangthai_txt = "da hoan thanh";
                    }
                    else
                    {
                        data.trangthai_btn = false;
                    }


                }
                else
                {
                    data.trangthai_btn = false;
                    data.trangthai_txt = "chua hoan thanh";
                }
                //FindObjectOfType<click_btn>().UpdateButtonState(data.id);
            }

        }
        datalist.save();
        //FindObjectOfType<view_quest>().CapNhatGiaoDien();
        FindObjectOfType<view_quest>().CapNhatGiaoDien(a);
    }


}

