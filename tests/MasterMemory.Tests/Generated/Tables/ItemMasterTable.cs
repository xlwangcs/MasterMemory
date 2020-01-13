// <auto-generated />
using MasterMemory.Tests.TestStructures;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System.Text;
using System;

namespace MasterMemory.Tests.Tables
{
   public sealed partial class ItemMasterTable : TableBase<ItemMaster>, ITableUniqueValidate
   {
        readonly Func<ItemMaster, int> primaryIndexSelector;


        public ItemMasterTable(ItemMaster[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.ItemId;
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public ItemMaster FindByItemId(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].ItemId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return default;
        }

        public ItemMaster FindClosestByItemId(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<ItemMaster> FindRangeByItemId(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
            ValidateUniqueCore(data, primaryIndexSelector, "ItemId", resultSet);       
        }

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(ItemMaster), typeof(ItemMasterTable), "item_master",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(ItemMaster).GetProperty("ItemId")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(ItemMaster).GetProperty("ItemId"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }
    }
}