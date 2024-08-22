using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/Quests", order = 1)]
public class quest_list : ScriptableObject
{
    [SerializeField]
    public List<dataquest> dataquestslist;
}
//[System.Serializable]
//public class dataquest
//{
//    public int id;
//    public Sprite anhr;
//    public string thongtin_txt;
//    public string tiendo_txt;
//    public bool trangthai_btn;
//    public string trangthai_txt;

//}