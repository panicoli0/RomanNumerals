using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField]
    string _inputString;

    // Start is called before the first frame update
    void Start()
    {
        RomanNumeralReduction(_inputString);
    }

    public void RomanNumeralReduction(string str)
    {
        RomanNumeralData RomanNumeral = new();

        var calculateObj = 0;

        var patternData = RomanNumeral.GetRomanNumeral().ToList();
        for (int i = 0; i < str.Length; i++)
        {
            var x = patternData.Where(_m => _m.RomanName.Equals(str[i].ToString())).FirstOrDefault();
            if (x is not null)
            {
                calculateObj += x.RomanValue;
            }
        }

        var converted = Convert(calculateObj);
        Debug.Log(converted);
    }

    public static string Convert(int calculateObj)
    {
        return calculateObj switch
        {
            1 => "I",
            5 => "V",
            10 => "X",
            50 => "L",
            100 => "C",
            200 => "CC",
            500 => "D",
            1000 => "M",
            _ => "",
        };
    }

    public class RomanNumeralData
    {
        public List<RomanPattern> GetRomanNumeral()
        {
            var data = new List<RomanPattern>();
            var item = new RomanPattern();

            data.Add(new RomanPattern { RomanName = "I", RomanValue = 1 });
            data.Add(new RomanPattern { RomanName = "V", RomanValue = 5 });
            data.Add(new RomanPattern { RomanName = "X", RomanValue = 10 });
            data.Add(new RomanPattern { RomanName = "L", RomanValue = 50 });
            data.Add(new RomanPattern { RomanName = "C", RomanValue = 100 });
            data.Add(new RomanPattern { RomanName = "D", RomanValue = 500 });
            data.Add(new RomanPattern { RomanName = "M", RomanValue = 1000 });

            return data;
        }
    }

    public class RomanPattern
    {
        public string RomanName { get; set; }
        public int RomanValue { get; set; } = 0;
    }
}
