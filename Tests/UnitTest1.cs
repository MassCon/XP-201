using App; //dpendencies -> project reference -> add App

namespace Tests;

[TestClass]
public class UnitTestApp
{
    private static Dictionary<String, int> parseTests = new()
        {
            { "I"          , 1    },
            { "II"         , 2    },
            { "III"        , 3    },
            { "IIII"       , 4    }, // Особливі твердження - з них ми визначаємо про
            { "IV"         , 4    }, // підтримку неоптимальних записів чисел
            { "V"          , 5    },
            { "VI"         , 6    },
            { "VII"        , 7    },
            { "VIII"       , 8    },
            { "IX"         , 9    },
            { "X"          , 10   },
            { "VV"         , 10   },  // Ще одне наголошення неоптимальності
            { "IIIIIIIIII" , 10   },  // Ще одне наголошення неоптимальності
            { "VX"         , 5    },  // Ще одне наголошення неоптимальності
            { "N"          , 0    },  // Доповнюємо множину чисел нулем
            { "-L"         , -50  },
            { "-XL"        , -40  },
            { "-IL"        , -49  },  // Неоптимальність
            { "-D"         , -500 },
            { "-C"         , -100 },
            { "-M"         , -1000 },
            { "D"          , 500 },
            { "C"          , 100 },
            { "M"          , 1000 },
            { "IM"         , 999 },
            { "-IM"        , -999 },
            { "IC"         , 99 },
            { "-IC"        , -99 },
            { "ID"         , 499 },
            { "-ID"        , -499 },
            { "VM"         , 995 },
            { "-VM"        , -995 },
            { "VC"         , 95 },
            { "-VC"        , -95 },
            { "VD"         , 495 },
            { "-VD"        , -495 },
            { "XM"         , 990 },
            { "-XM"        , -990 },
            { "XC"         , 90 },
            { "-XC"        , -90 },
            { "XD"         , 490 },
            { "-XD"        , -490 },
            { "MI"         , 1001 },
            { "-MI"        , -1001 },
            { "CI"         , 101 },
            { "-CI"        , -101 },
            { "DI"         , 501 },
            { "-DI"        , -501 },
            { "MV"         , 1005 },
            { "-MV"        , -1005 },
            { "CV"         , 105 },
            { "-CV"        , -105 },
            { "DV"         , 505 },
            { "-DV"        , -505 },
            { "MX"         , 1010 },
            { "-MX"        , -1010 },
            { "CX"         , 110 },
            { "-CX"        , -110 },
            { "DX"         , 510 },
            { "-DX"        , -510 },/////////////  
            {"LX"          , 60 },
            {"LXII"        , 62 },
            {"CCL"         , 250 },
            {"-CCIII"      , -203 },
            {"-LIV"        ,  -54},
            {"MDII"        , 1502 },
            //{"-CCM"        , -800 },
            {"DD"          ,1000 },
            {"CCCCC"       ,500 },
            {"IVIVIVIVIV"  ,20 },
            {"CDIV"        ,404},
            { "CCCC"       , 400 },
            { "LM"         , 950 },
            { "CDX"        , 410 },
            { "DDD"        , 1500 },
            { "MDCC"       , 1700 },
            { "DDDIV"      , 1504 },
            { "MMMM"       , 4000 },

            { "LXIV"       , 64 },
            
            { "XXVII"      , 27 },
            
            { "LI"         , 51 },
            { "LXXXIV"     , 84 },
            { "LXX"        , 70 },
            { "XXXV"       , 35 },
            { "LXXXII"     , 82 },
            { "XXXIII"     , 33 },
            { "LV"         , 55 },
            { "LXIX"       , 69 },
            { "CLXXXVI"    , 186 },
            { "DCCLI"      , 751 },
            { "CMXI"       , 911 },
            { "DCLX"       , 660 },
            { "DCCCXVII"   , 817 },
            { "DLXVII"     , 567 },
    };


    [TestMethod]
    public void TestRomanNumberParse()
    {
        /*
        Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");

        Assert.AreEqual(2, RomanNumber.Parse("II").Value, "2 == II");

        Assert.AreEqual(3, RomanNumber.Parse("III").Value, "3 == III");
        */

        foreach (var pair in parseTests)
        {
            Assert.AreEqual(
                pair.Value,
                RomanNumber.Parse(pair.Key).Value,
                $"{pair.Value} == {pair.Key}");
        }
    }


}


