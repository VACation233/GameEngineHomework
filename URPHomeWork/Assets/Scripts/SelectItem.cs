using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public struct TroopItem
    {
        
        int id; int type;
        int level; int load;
        int force; int own_num; int select_num;
        List<TroopItem> QuickSelectTroopList(int res_max, int march_size_max, List<TroopItem> own_troop_list)
        {
            int number=own_troop_list.Count;
            int currentRes = 0;
            int currentMarchSize = 0;
            int leftRes = res_max;
            int leftMarchSize = march_size_max;
            List<TroopItem> troop_list = new List<TroopItem>();
            //Ã∞¿∑À„∑®
            int[,] dp = new int[number + 1,number+1];
            foreach(TroopItem item in own_troop_list)
            {
                if(item.own_num<= leftMarchSize)
                {
                    int sublRes = item.load * item.own_num;

                    if (sublRes < leftRes)
                    {
                        currentMarchSize = item.own_num;
                        currentRes += sublRes;
                    }
                    
                }
            }

            return troop_list;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
