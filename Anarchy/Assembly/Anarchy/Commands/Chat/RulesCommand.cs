﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anarchy.Commands.Chat
{
    internal class RulesCommand : ChatCommand
    {
        public RulesCommand() : base("rules", false, true, false)
        {

        }

        public override bool Execute(string[] args)
        {
            string toAdd = GameModes.GetGameModesInfo();
            if (toAdd.Length > 0)
            {
                UI.Chat.Add(toAdd);
            }
            return true;
        }
    }
}
