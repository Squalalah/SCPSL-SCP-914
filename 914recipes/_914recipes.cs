using Smod2;
using Smod2.Attributes;
using Smod2.Events;
using Smod2.API;
using Smod2.EventHandlers;
using System.Collections.Generic;
using UnityEngine;

namespace _914recipes
{
    [PluginDetails(
        author = "Squalalah",
        name = "912 recipes",
        description = "912 recipes",
        id = "squal.912.recipes",
        version = "1.2.0",
        SmodMajor = 3,
        SmodMinor = 1,
        SmodRevision = 12
        )]
    class _914recipes : Plugin
    {
        public override void OnDisable()
        {
            this.Info("912 recipes unloaded successfully.");
        }

        public override void OnEnable()
        {
            this.Info("912 recipes loaded successfully.");

        }

        public override void Register()
        {
            _914recipesEventHandler eventh = new _914recipesEventHandler(this);
            this.AddEventHandler(typeof(IEventHandlerRoundStart), eventh, Priority.Highest);

        }
    }
}
