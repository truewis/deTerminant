using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spells;

public class Spell_Root : Spell{

    public Spell_Root(AsteriskHex parent) : base(parent) {
        List<Symbol> list = new List<Symbol>();
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, 0, 1));
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.red, 1, 2));
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.blue, 2, 3));
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.magenta, 3, 4));
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.yellow, 4, 5));
        list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.cyan, 5, 6));
        parent.addSymbol(list);
    }

    public override bool pressed(int value)
    {
        if (value == -1)
            return false;
        else if (value > 0)
        {
            if(value == 2)
            {
                parent.spell = new Spell_FireRoot(parent);
            }
            return true;
        }
        return false;
    }
}
