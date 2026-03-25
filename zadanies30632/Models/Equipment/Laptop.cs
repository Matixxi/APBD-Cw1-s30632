namespace zadanies30632.Models.Equipment;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string ProcessorModel { get; set; }
    public Laptop(string name, int ramGb, string processorModel) : base(name)
    {
        RamGb = ramGb ;
        ProcessorModel = processorModel;
    }

    public override string ToString()
    {
        return base.ToString() + " | RAM: " + RamGb + "GB, CPU: " + ProcessorModel;
    }
    
}