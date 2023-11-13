using App; //dpendencies -> project reference -> add App

namespace Tests;

[TestClass]
public class UnitTestApp
{
    [TestMethod]
    public void TestToString()
    {
        Dictionary<int, String> testCases = new()
        {
            /*
             { 1, "I"},
            { 2, "II"},
            { 5, "V"},
            { 13, "XIII"},
            { 640, "DCXL"},
            { 2267, "MMCCLXVII"},
            { 518, "DXVIII"},
            { 2680, "MMDCLXXX"},
            { 957, "CMLVII"},
            { 1837, "MDCCCXXXVII"},
            */
            //{0, "N" },
            {1, "I" },
            {2, "II" },
            {3, "III" },
            {4, "IV" },
            {5, "V" },
            {6, "VI" },
            {7, "VII" },
            {8, "VIII" },
            {9, "IX" },
            {10, "X" },
            {11, "XI" },
            {12, "XII" },
            {13, "XIII" },
            {14, "XIV" },
            {15, "XV" },
            {16, "XVI" },
            {17, "XVII" },
            {18, "XVIII" },
            {19, "XIX" },
            {20, "XX" },
            {21, "XXI" },
            {22, "XXII" },
            {23, "XXIII" },
            {29, "XXIX"},
            {30, "XXX" },
            {33, "XXXIII" },
            {39, "XXXIX"},
            {40, "XL" },
            {44, "XLIV" },
            {48, "XLVIII" },
            {50, "L" },
            {51, "LI" },
            {52, "LII" },
            {55, "LV" },
            {59, "LIX" },
            {62, "LXII" },
            {64, "LXIV" },
            {66, "LXVI" },
            {75, "LXXV" },
            {77, "LXXVII" },
            {81, "LXXXI" },
            {88, "LXXXVIII" },
            {90, "XC" },
            {92, "XCII" },
            {99, "XCIX" },
            {100, "C" },
            {105, "CV" },
            {107, "CVII" },
            {111, "CXI" },
            {115, "CXV" },
            {123, "CXXIII" },
            {222, "CCXXII" },
            {234, "CCXXXIV" },
            {246, "CCXLVI"},
            {321, "CCCXXI" },
            {333, "CCCXXXIII" },
            {345, "CCCXLV" },
            {378, "CCCLXXVIII"},
            {404, "CDIV" },
            {444, "CDXLIV" },
            //{456, "CDXLIV" },
            {500, "D" },
            {555, "DLV" },
            {567, "DLXVII" },
            {609, "DCIX" },
            {666, "DCLXVI" },
            {678, "DCLXXVIII" },
            {777, "DCCLXXVII" },
            {789, "DCCLXXXIX" },
            {888, "DCCCLXXXVIII" },
            {890, "DCCCXC" },
            {901, "CMI" },
            {999, "CMXCIX" },
            {1000, "M" },
            //{1007, "MMVII" },
            {1111, "MCXI" },
            {1199, "MCXCIX"},
            {1234, "MCCXXXIV" },
            {1317, "MCCCXVII" },
            {1350, "MCCCL"},
            {1432, "MCDXXXII" },
            {1500, "MD" },
            {1575, "MDLXXV" },
            {1632, "MDCXXXII" },
            {1667, "MDCLXVII" },
            {1734, "MDCCXXXIV" },
            {1872, "MDCCCLXXII" },
            {1969, "MCMLXIX" },
            {1985, "MCMLXXXV" },
            {2023, "MMXXIII" },
            {2048, "MMXLVIII" },
            //{2107, "MMMMCVII" },
            {2184, "MMCLXXXIV" },
            {2222, "MMCCXXII" },
            {2247, "MMCCXLVII"},
            {2288, "MMCCLXXXVIII" },
            {2345, "MMCCCXLV" },
            {2392, "MMCCCXCII" },
            {2496, "MMCDXCVI" },
            {2499, "MMCDXCIX"},
            {2500, "MMD" },
            {2678, "MMDCLXXVIII" },
            {2700, "MMDCC"},
            {2781, "MMDCCLXXXI" },
            {2884, "MMDCCCLXXXIV" },
            {2958, "MMCMLVIII" },
            {2999, "MMCMXCIX"},
            {3000, "MMM" },


        };

        foreach (var pair in testCases)
        {
            Assert.AreEqual(
                pair.Value, new RomanNumber(pair.Key).ToString(), $"{pair.Key}.ToString == '{pair.Value}'");
        }

        Random r = new Random();
        for (int i = 0; i < 256; i++)
        {
            int number = r.Next(-3000, 3001);
            Assert.AreEqual(number, RomanNumber.Parse(new RomanNumber(number).ToString()).Value, $"{number}.ToString == {new RomanNumber(number).ToString()}");
        }

    }

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
            { "CDIV "     , 404 },
            { " CDIV "     , 404 },
            { "\nCDIV\t"     , 404 },

             { "-MMMMI"         , -4001 },
            { "-MMMI"         , -3001 },
            { "MMMI"         , 3001 },
            { "MMMMV"         , 4005 },
            { "-MMMMV"         , -4005 },
            { "-MMMV"         , -3005 },
            { "MMMV"         , 3005 },
            { "MMMMX"         , 4010 },
            { "-MMMMX"         , -4010 },
            { "-MMMX"         , -3010 },
            { "MMMX"         , 3010 },
            { "MMMMXV"         , 4015 },
            { "-MMMMXV"         , -4015 },
            { "-MMMXV"         , -3015 },
            { "MMMXV"         , 3015 },

    };

    [TestMethod]
    public void TestRomanNumberParseValid()
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

    [TestMethod]
    public void TestRomanNumberParseNonValid()
    {
        Assert.ThrowsException<ArgumentException>(
        () => RomanNumber.Parse(""),
        "'' -> Exception");

        Assert.ThrowsException<ArgumentException>(
        () => RomanNumber.Parse(null!),
        "null -> Exception");

        Assert.ThrowsException<ArgumentException>(
        () => RomanNumber.Parse("   "),
        "'  ' -> Exception");

        /*
        var ex = Assert.ThrowsException<ArgumentException>(
        () => RomanNumber.Parse("XBC"),
        "ABC -> Exception");
        Assert.IsTrue(ex.Message.Contains("'B'"), "ex.Message.Contains 'B' ");
        */

        //KeyValuePair<String, char> pair = new ("Xx", 'x');
        Dictionary<String, char> testCases = new()
        {
            { "Xx", 'x' },
            { "Xy", 'y' },
            { "AX", 'A' },
            { "X C", ' ' },
            { "X\tC", '\t' },
            { "X\nC", '\n' },
        };
        foreach (var pair in testCases)
        {
            Assert.IsTrue(
            Assert.ThrowsException<ArgumentException>(
           () => RomanNumber.Parse(pair.Key),
           $"'{pair.Key}' -> ArgumentException").Message.Contains($"'{pair.Value}'"),
            $"'{pair.Key}' ex.Message.Contains '{pair.Value}' ");
        }

        var ex = Assert.ThrowsException<ArgumentException>(
        () => RomanNumber.Parse("ABC"),
        "'' -> Exception");

        /*
        Assert.IsTrue(ex.Message.Contains('A') || ex.Message.Contains('B'),
            "'ABC' ex.Message.Contain either 'A' or 'B'");
        */

        Assert.IsTrue(ex.Message.Contains('A') && ex.Message.Contains('B'),
            "'ABC' ex.Message should Contain 'A' and 'B'");

        Assert.IsFalse(ex.Message.Length < 15, "ex.Message.Length min 15");
    }

    [TestMethod]
    public void TestRomanNumberParseIllegal()
    {
        string[] illegals = { "IIV", "IIX", "VVX", "IVX", "IIIX", "VIX", "IVIX", "VIIX", "VVVX", "IVVVIX", };
        foreach (var illegal in illegals)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(illegal), $"'{illegal}' -> Exception");
        }
    }

    [TestMethod]
    public void TestAdd()
    {
        RomanNumber r1 = new(10);
        RomanNumber r2 = new(20);
        Assert.IsInstanceOfType(r1.Add(r2), typeof(RomanNumber));
        Assert.AreEqual("XXX", r1.Add(r2).ToString());
        Assert.AreEqual(30, r1.Add(r2).Value);
        Assert.AreEqual("XXX", r2.Add(r1).ToString());
        Assert.AreEqual(30, r2.Add(r1).Value);
        //var ex = Assert.ThrowsException<ArgumentNullException>(
        var ex = Assert.ThrowsException<ArgumentException>(
            () => r1.Add(null!),
            //"r1.Add(null!) -> ArgumentNullException
            "r1.Add(null!) -> ArgumentException"
        );
        Assert.IsTrue(ex.Message.Contains("Cannot Add null object", StringComparison.OrdinalIgnoreCase), $"ex.Message({ex.Message}) contains 'Cannot Add null object'");

        //Assert.AreNotSame(r2, r2.Add(r1), "Add() should return new item");
    }

    [TestMethod]
    public void TestSum()
    {
        RomanNumber r1 = new(10);
        RomanNumber r2 = new(20);
        var r3 = RomanNumber.Sum(r1, r2);
        Assert.IsInstanceOfType(r3, typeof(RomanNumber));
        Assert.AreNotSame(r3, r1);
        Assert.AreNotSame(r3, r2);

        Assert.AreEqual(60, RomanNumber.Sum(r1, r2, r3).Value);

        var ex = Assert.ThrowsException<ArgumentNullException>(
            () => RomanNumber.Sum(null!),
            "Sum(null!) ThrowsException: ArgumentNullException");
        String expectedFragment = "Invalid Sum() invocation with NULL argument";

        Assert.IsTrue(
            ex.Message.Contains(
                expectedFragment,
                StringComparison.InvariantCultureIgnoreCase
            ),
            $"ex.Message({ex.Message}) contains '{expectedFragment}'"
        );
        var emptyArr = Array.Empty<RomanNumber>();  
        Assert.AreEqual(0, RomanNumber.Sum(emptyArr).Value, "Sum(empty) == 0");
        Assert.AreEqual(0, RomanNumber.Sum().Value, "Sum() == 0");

        Assert.AreEqual(10, RomanNumber.Sum(r1).Value, "Sum(r1) == 10");

        Assert.AreEqual(0, RomanNumber.Sum(new(10), new(-10)).Value);
        Assert.AreEqual(-1, RomanNumber.Sum(new(10), new(-11)).Value);
        Assert.AreEqual(1, RomanNumber.Sum(new(10), new(-9)).Value);
        Random rnd = new();
        for (int i = 0; i < 200; i += 1)
        {
            int x = rnd.Next(-3000, 3000);
            int y = rnd.Next(-3000, 3000);
            Assert.AreEqual(
                x + y,
                RomanNumber.Sum(new(x), new(y)).Value,
                $"{x} + {y} == {x + y}"
            );
        }
        for (int i = 0; i < 200; i += 1)
        {
            RomanNumber x = new(rnd.Next(-3000, 3000));
            RomanNumber y = new(rnd.Next(-3000, 3000));
            Assert.AreEqual(
                x.Add(y).Value,
                RomanNumber.Sum(x, y).Value,
                $"{x}, {y} Add == Sum"
            );
        }
    }
}


