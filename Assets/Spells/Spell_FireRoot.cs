using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spells;

public class Spell_FireRoot : Spell {
	private int state = 0;

	public Spell_FireRoot (AsteriskHex parent) : base(parent)
	{
		List<Symbol> list = new List<Symbol>();
		list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.white, 0, 0));
		list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.red, 1, 1));
		list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.magenta, 3, 3));
		list.Add(new Symbol(Resources.Load<Sprite>("smallhex"), Color.cyan, 5, 5));
		list.Add(new Symbol(Resources.Load<Sprite>("smallcircle"), Color.white, 2, 6));
		list.Add(new Symbol(Resources.Load<Sprite>("smallcircle"), Color.white, 4, 6));

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
		else
		{
            switch (state)
            {
                case 0:
                    if (value == 6) parent.spell = new Spell_Fire(parent);
                    break;
            }
			return false;
		}
	}

}
