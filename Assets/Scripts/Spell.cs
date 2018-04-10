using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The schematics of spells. Determines properties of symbols that appear, including responses.
/// </summary>
public abstract class Spell{
    protected AsteriskHex parent;
    public Spell (AsteriskHex parent)
    {
        this.parent = parent;
    }

    public abstract bool pressed(int value);

}

/// <summary>
/// Internal Symbol datas. Used in lists in Spell class.
/// </summary>
public struct Symbol
{
    //public static readonly Color indigo = new Color(0, 0, 0.5f);
    public Symbol(Sprite img, Color color, int pos, int value)
    {
        this.img = img;
        this.color = color;
        this.pos = pos;
        this.value = value;
    }
    public Sprite img;
    public Color color;
    public int pos;
    public int value;
}