using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spells;

public class AsteriskHex : MonoBehaviour {
    public int num = 1;
    public float dimspeed = 0.03f;
    public Spell spell { get; set; }
    private Queue<List<SymbolInstance>> queue;

    private const float dist = 20;
    private const float sin60 = 0.86602540378443864676372317075294f;
    private static readonly Vector3[] ratio = { new Vector3(0, 1),
                                                new Vector3(sin60, .5f),
                                                new Vector3(sin60, -.5f),
                                                new Vector3(0, -1),
                                                new Vector3(-sin60, -.5f),
                                                new Vector3(-sin60, .5f) };


    private float targetAlpha = .05f;
    
    private CanvasGroup hexRend;
    // Use this for initialization
    void Start() {
        queue = new Queue<List<SymbolInstance>>();
        spell = new spell_test(this);
        hexRend = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update() {
        
        
        bool end = false;
        bool pressed = false;
        for(int i=0; i<6; i++)
        {
            if (Input.GetKey(KeymapManager.root.keymap[string.Format("asterisk{0}{1}", num, i)])) //버튼이 눌리면
            {
                pressed = true;
            }
                if (Input.GetKeyDown(KeymapManager.root.keymap[string.Format("asterisk{0}{1}", num, i)])) //버튼이 눌리면
            {
                
                foreach (SymbolInstance s in queue.Peek()) //다음층 심볼중에
                {
                    if (s.pos == i) //해당 심볼이 있다면
                    {
                        if (spell.pressed(s.value)) adv(); //신호보내고 진행
                        end = true;
                        break;
                    }
                }
                if (!end) //해당 심볼이 없다면
                {
                    if (spell.pressed(-1)) adv();
                }
                break;
            }
        }
        if (pressed) targetAlpha += 2.0f * Time.deltaTime; else targetAlpha -= 0.4f *Time.deltaTime;
        targetAlpha = Mathf.Clamp(targetAlpha, 0.05f, 0.5f);
        DebugPanel.Log("targetAlpha", targetAlpha);
        hexRend.alpha = targetAlpha;
    }

    /// <summary>
    /// Instantiate one line of Symbols.
    /// </summary>
    /// <param name="symbols"></param>
    public void addSymbol(List<Symbol> symbols)
    {
        List<SymbolInstance> list = new List<SymbolInstance>();
        foreach(Symbol s in symbols)
        {
            GameObject g = new GameObject("symbol");
            Image i = g.AddComponent<Image>();
          
            i.rectTransform.SetParent(transform);
            i.sprite = s.img;
            
            i.color = s.color;
            
            i.rectTransform.localPosition = ratio[s.pos] * dist * (1 + queue.Count) + Vector3.back;
            i.rectTransform.sizeDelta = new Vector2(20.5f, 20);
            list.Add(new SymbolInstance(i, s.pos, s.value));
        }
        queue.Enqueue(list);
    }

    /// <summary>
    /// Brings next line inward.
    /// </summary>
    public void adv()
    {
        foreach(SymbolInstance i in queue.Dequeue()) //가장 안쪽 라인 삭제
        {
            Destroy(i.img.gameObject);
        }
        int d = 1;
        foreach(List<SymbolInstance> l in queue.ToArray()) //다른 라인 안쪽으로 이동
        {
            foreach(SymbolInstance i in l)
            {
                i.img.rectTransform.localPosition = ratio[i.pos] * dist * d + Vector3.back;
            }
            d++;
        }
    }

    /// <summary>
    /// Destroy every symbol and go back to root spell.
    /// </summary>
    public void Terminate()
    {
        foreach(List<SymbolInstance> l in queue)
        {
            foreach(SymbolInstance i in l)
            {
                Destroy(i.img.gameObject);
            }
        }
        queue.Clear();
        spell = new Spell_Root(this);
    }
}

/// <summary>
/// Data of Symbol that actually gets instantiated. Visual.
/// </summary>
public struct SymbolInstance
{
    public Image img;
    public int pos;
    public int value;
    public SymbolInstance(Image img, int pos, int value)
    {
        this.img = img;
        this.pos = pos;
        this.value = value;
    }
}
