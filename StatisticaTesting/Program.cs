using System;
using Sandbox.ModAPI.Ingame;
using IngameScript.Pulse.Template;
using System.Collections;
using System.Collections.Generic;
using IngameScript.Pulse.Testing.Models;
using System.Linq;
using VRage.Game.ModAPI.Ingame;


namespace IngameScript.AIB.Core.Statistica
{
    abstract class BaseCollector<TBlockType, KModelType> : ICollect<KModelType> 
        where KModelType: BaseDataModel
        where TBlockType: IMyEntity
    {
        protected readonly TBlockType[] _blocks;

        protected BaseCollector(IEnumerable<TBlockType> blocks)
        {
            _blocks = blocks.Select(x => x).Where(x => x != null).ToArray();
        }

        public abstract KModelType[] Collect();

    }

    class PowerUsageCollector: BaseCollector<IMyTerminalBlock,DataModel>
    {
        public PowerUsageCollector(IEnumerable<IMyTerminalBlock> blocks) : base(blocks)
        {
        }

        public override DataModel[] Collect()
        {
            DataModel[] models = new DataModel[_blocks.Length];
            int index = 0;

            foreach (var block in _blocks)
            {
                models[index++] = new DataModel()
                {
                    Id = block.EntityId,
                    Name = block.CustomName,
                    Value = block.Powe
                };
            }

            return models;
        }    
    }

    class GasTankCollector : BaseCollector<IMyGasTank, DataModel>
    {
        public GasTankCollector(IEnumerable<IMyGasTank> blocks) : base(blocks)
        {
        }

        public override DataModel[] Collect()
        {
            DataModel[] models = new DataModel[_blocks.Length];
            int index = 0;

            foreach (var block in _blocks)
            {
                models[index++] = new DataModel()
                {
                    Id = block.EntityId,
                    Name = block.CustomName,
                    Value = block.Capacity
                };
            }

            return models.ToArray();
        }
    }

    interface ICollect<T> where T : BaseDataModel
    {
        T[] Collect();
    }

    class DataModel: BaseDataModel
    {       
        public float Value { get; set; }
    }    

    class CargoDataModel: BaseDataModel
    {     
        public DataModel[] Items { get; set; }
    }

    class BaseDataModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    //will collect: power usage, items transfers & usage, gas using
    //power usage {powerBlocks{Id,name ,value}}
    //gas using {gasBlocks{Id,name, value}}
    //items transfers & usage {cargoBlock, items {item {id, name}, value}}
}

namespace IngameScript
{
    partial class Program : ITemplateProgram
    {
        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Execute(string argument, UpdateType updateSource)
        {
            throw new NotImplementedException();
        }        
    }
}
