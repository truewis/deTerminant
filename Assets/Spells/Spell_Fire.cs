using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Fire : Spell
{
    static readonly int requiredSymbols = 5;
    private int doneSymbols = 0;

    public Spell_Fire(AsteriskHex parent) : base(parent)
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
    }

    public override bool pressed(int value)
    {
        throw new NotImplementedException();
    }
}