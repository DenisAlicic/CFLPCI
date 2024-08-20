namespace CFLPCI;

public struct OptimizationData
{
    public int WarehousesNum;
    public int StoresNum;
    public List<int> Capacity;
    public List<int> FixedCost;
    public List<int> Goods;
    public List<List<int>> SupplyCost;
    public int IncompabilitiesNum;
    public List<Tuple<int, int>> IncompabilitiesPairs;
}