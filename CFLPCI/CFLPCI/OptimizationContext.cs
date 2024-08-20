using CFLPCI.Utility;

namespace CFLPCI;

public class OptimizationContext
{
    private OptimizationData data;
    
    public OptimizationContext(String path)
    {
        data = DznReader.ReadDataFromFile(path);
    }

    public void Optimize()
    {
        
    }
}