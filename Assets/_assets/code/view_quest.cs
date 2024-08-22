using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_quest : MonoBehaviour
{
    public quest_list Quest_list;
    public datalist Ddatalist;
    public get_quest get_Quest;
    public Transform vitri;

    private Dictionary<int, get_quest> questDictionary = new Dictionary<int, get_quest>();

    public void Start()
    {
        Ddatalist.LoadAll();
        foreach (var data in Quest_list.dataquestslist)
        {
            //savequest index= Ddatalist.saveDataQuest.Find(index=>index.id==data.id);
            taora(data);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void taora(dataquest dataquest)
    {
        var quest = Instantiate(get_Quest, vitri);
        quest.Setdata(dataquest);

        questDictionary[dataquest.id] = quest;


    }
    //public void CapNhatGiaoDien()
    //{
    //    LoadAndCreateQuests();
    //}
    //public void LoadAndCreateQuests()
    //{

    //    foreach (Transform child in vitri)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    Ddatalist.LoadAll();
    //    foreach (var data in Quest_list.dataquestslist)
    //    {
    //        taora(data);
    //    }
    //}
    public void CapNhatGiaoDien(int id)
    {
        if (questDictionary.TryGetValue(id, out get_quest quest))
        {
            // Tìm dữ liệu mới cho đối tượng
            var data = Quest_list.dataquestslist.Find(d => d.id == id);
            if (data != null)
            {
                quest.Setdata(data);
            }
        }
    }

}
