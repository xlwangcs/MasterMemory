// <auto-generated />
using ConsoleApp;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System;

namespace ConsoleApp.Tables
{
   public sealed partial class QuestTable : TableBase<Quest>, ITableUniqueValidate
   {
        readonly Func<Quest, int> primaryIndexSelector;


        public QuestTable(Quest[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Id;
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public Quest FindById(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindById(int key, out Quest result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public Quest FindClosestById(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<Quest> FindRangeById(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
            ValidateUniqueCore(data, primaryIndexSelector, "Id", resultSet);       
        }

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(Quest), typeof(QuestTable), "quest_master",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(Quest).GetProperty("Id")),
                    new MasterMemory.Meta.MetaProperty(typeof(Quest).GetProperty("Name")),
                    new MasterMemory.Meta.MetaProperty(typeof(Quest).GetProperty("RewardId")),
                    new MasterMemory.Meta.MetaProperty(typeof(Quest).GetProperty("Cost")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(Quest).GetProperty("Id"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }
    }
}