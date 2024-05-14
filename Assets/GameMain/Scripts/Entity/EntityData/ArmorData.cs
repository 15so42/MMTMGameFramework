﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using UnityEngine;

namespace GameMain
{
    [Serializable]
    public class ArmorData : AccessoryObjectData
    {
       
        private string path;
        
        //属性
        public ChaProperty[] propMod=new ChaProperty[2];

        public ArmorData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId, ownerId, ownerCamp)
        {
            IDataTable<DRArmor> dtArmor = GameEntry.DataTable.GetDataTable<DRArmor>();
            DRArmor drArmor = dtArmor.GetDataRow(TypeId);
            if (drArmor == null)
            {
                return;
            }
            
            path = drArmor.Path;
            
            //属性
            propMod[0].hp = drArmor.HPAdd;
            propMod[0].mp = drArmor.MPAdd;
            propMod[0].attack = drArmor.AttackAdd;
            propMod[0].defense = drArmor.DefenseAdd;

            propMod[1].hp = drArmor.HPTimes;
            propMod[1].mp = drArmor.MPTimes;
            propMod[1].attack = drArmor.AttackTimes;
            propMod[1].defense = drArmor.DefenseTimes;
        }

        

        public string Path
        {
            get
            {
                return path;
            }
        }
    }
}
