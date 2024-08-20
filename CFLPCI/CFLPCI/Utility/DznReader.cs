namespace CFLPCI.Utility;

public static class DznReader
{
    public static OptimizationData ReadDataFromFile(string filePath)
    {
        var data = new OptimizationData();

        var lines = File.ReadAllLines(filePath);
        var nextParseLine = 0;

        data.SupplyCost = new List<List<int>>();

        data.WarehousesNum = int.Parse(lines[nextParseLine].Split("=")[1].Trim(' ', ';'));
        nextParseLine++;
        data.StoresNum = int.Parse(lines[nextParseLine].Split("=")[1].Trim(' ', ';'));
        // Skip empty line
        nextParseLine += 2;

        data.Capacity = ReadList(lines[nextParseLine].Split("=")[1]);
        nextParseLine++;
        data.FixedCost = ReadList(lines[nextParseLine].Split("=")[1]);
        nextParseLine++;
        data.Goods = ReadList(lines[nextParseLine].Split("=")[1]);
        nextParseLine++;
        var firstLine = lines[nextParseLine].Split("=")[1];
        data.SupplyCost.Add(ReadList(firstLine));
        nextParseLine++;
        for (var i = 0; i < data.StoresNum - 1; i++)
        {
            data.SupplyCost.Add(ReadList(lines[nextParseLine]));
            nextParseLine++;
        }

        //Skip empty line
        nextParseLine++;
        data.IncompabilitiesNum = int.Parse(lines[nextParseLine].Split("=")[1].Trim(' ', ';'));
        nextParseLine++;
        data.IncompabilitiesPairs = ReadTupleList(lines[nextParseLine].Split("=")[1]);
        return data;
    }

    private static List<int> ReadList(string pythonLikeList)
    {
        List<int> numberList = new();
        pythonLikeList = pythonLikeList.Trim('[', ']', '|', '\t', '\n', ' ', ';');
        foreach (var number in pythonLikeList.Split(", "))
        {
            numberList.Add(int.Parse(number.Trim()));
        }

        return numberList;
    }

    private static List<Tuple<int, int>> ReadTupleList(string pythonLikeList)
    {
        List<Tuple<int, int>> tuppleList = new();
        pythonLikeList = pythonLikeList.Trim('[', ']', '|', '\t', '\n', ' ', ';');
        foreach (var tupple in pythonLikeList.Split("|"))
        {
            var numbers = tupple.Split(",");
            tuppleList.Add(new Tuple<int, int>(int.Parse(numbers[0].Trim()), int.Parse(numbers[1].Trim())));
        }

        return tuppleList;
    }
}