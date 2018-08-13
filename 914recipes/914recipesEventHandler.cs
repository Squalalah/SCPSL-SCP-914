using Smod2;
using Smod2.Attributes;
using Smod2.Events;
using Smod2.API;
using Smod2.EventHandlers;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

namespace _914recipes
{
    [XmlType("_914recipes._914recipesEventHandler")]
    class _914recipesEventHandler : IEventHandlerRoundStart
    {
        private Plugin plugin;

        public _914recipesEventHandler(Plugin plugin)
        {
            this.plugin = plugin;
            plugin.Info("EventHandler créer");
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            plugin.Info("OnRoundStart lancé");
            //InsertCoinRecipe();
            CreateFile();
        }

        #region CreateFile()
        /// <summary>
        /// Fonction permettant de créer et charger le fichier de configuration de SCP-914
        /// </summary>
        public void CreateFile()
        {
            List<string> names = new List<string>();
            List<string> state = new List<string>();
            Scp914 scp914 = UnityEngine.Object.FindObjectOfType<Scp914>();
            if (scp914 == null) { plugin.Info("SCP-914 introuvable pour la création du fichier de configuration"); return; }
            plugin.Info("Nombre de recipes dans scp914 : " + scp914.recipes.Length);
            if (!System.IO.File.Exists("914recipes.txt"))
            {
                string text = "";
                ItemType type, type2;
                KnobSetting knob;

                int count = 0;
                foreach(Scp914.Recipe r in scp914.recipes)
                {
                    int countstate = 0;
                    type = (ItemType)count;
                    text += type.ToString() + "-";
                    foreach (Scp914.Recipe.Output o in r.outputs)
                    {
                        
                        knob = (KnobSetting)countstate;
                        if (countstate == 0) text += knob.ToString() + ":";
                        else text += type.ToString() + "-" + knob.ToString() + ":";
                        foreach(int i in o.outputs)
                        {
                            
                            type2 = (ItemType)i;
                            text += type2.ToString() + ",";
                        }
                        text += Environment.NewLine;
                        countstate++;
                    }
                    count++;
                }
                System.IO.File.WriteAllText("914recipes.txt", text);
            }
            else
            {
                string[] text = System.IO.File.ReadAllLines("914recipes.txt");
#pragma warning disable CS0162 // Impossible d'atteindre le code détecté
                for (int a = 0; a < text.Length; a++)
#pragma warning restore CS0162 // Impossible d'atteindre le code détecté
                {
                    string[] spliter = text[a].Split('-');
                    int number = (int)Enum.Parse(typeof(ItemType), spliter[0]);
                    string[] knob = spliter[1].Split(':');
                    int knobvalue = (int)Enum.Parse(typeof(KnobSetting), knob[0]);
                    string[] values = knob[1].Split(',');
                    scp914.recipes[number].outputs[knobvalue].outputs.Clear();
                    int value;
                    for (int b = 0; b < values.Length; b++)
                    {
                        if (values[b] == string.Empty) continue;
                        value = (int)Enum.Parse(typeof(ItemType), values[b]);
                        scp914.recipes[number].outputs[knobvalue].outputs.Add(value);
                    }
                }
            }
        }
        #endregion
    }
}
