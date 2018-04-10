using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class spell_test : Spell
    {
        public spell_test(AsteriskHex parent) : base(parent) {
            List<Symbol> list = new List<Symbol>();
            Symbol s;
            s.img = Resources.Load<Sprite>("smallhex");
            s.color = Color.red;
            s.pos = 0;
            s.value = 1;
            list.Add(s);
            s.color = new Color(1,.8f, 0);
            s.pos = 1;
            s.value = 2;
            list.Add(s);
            s.color = Color.yellow;
            s.pos = 2;
            s.value = 3;
            list.Add(s);
            s.color = Color.green;
            s.pos = 3;
            s.value = 4;
            list.Add(s);
            s.color = Color.cyan;
            s.pos = 4;
            s.value = 5;
            list.Add(s);
            s.color = new Color(.8f, 0, 1);
            s.pos = 5;
            s.value = 6;
            list.Add(s);
            parent.addSymbol(list);
        }
            
        public override bool pressed(int value)
        {
            if (value == -1)
                return false;
            else if (value == 0)
            {
                List<Symbol> list = new List<Symbol>();
                list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, UnityEngine.Random.Range(0, 6), 0));
                parent.addSymbol(list);
                return true;
            }
            else if (value > 0)
            {
                List<Symbol> list = new List<Symbol>();
                list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, UnityEngine.Random.Range(0, 6), 0));
                parent.addSymbol(list);
                list = new List<Symbol>();
                list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, UnityEngine.Random.Range(0, 6), 0));
                parent.addSymbol(list);
                list = new List<Symbol>();
                list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, UnityEngine.Random.Range(0, 6), 0));
                parent.addSymbol(list);
                list = new List<Symbol>();
                list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, UnityEngine.Random.Range(0, 6), 0));
                parent.addSymbol(list);
                return true;
            }
            return false;
        }
    }
}
