using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class get_quest : MonoBehaviour
{
    public dataquest Dataquest;
   

    public Image icon_img;
    public Text thongtin_text;
    public Text tiendo_text;
    public Button trangthai_button;
    public Text trangthai_text;


    public void Setdata(dataquest dataquest )
    {
        this.Dataquest = dataquest;
      
        updateUI();
    }
    //lay du lieu tu ScriptableObject vao doi tuong 
    public void updateUI()
    {
        icon_img.sprite = Dataquest.anh_img;
        thongtin_text.text = Dataquest.thongtin_txt;
        tiendo_text.text = Dataquest.tiendo_txt;
        trangthai_button.interactable = Dataquest.trangthai_btn;
        trangthai_text.text = Dataquest.trangthai_txt;

    }









}
