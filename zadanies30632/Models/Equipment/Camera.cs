namespace zadanies30632.Models.Equipment;

public class Camera : Equipment
{
    public int MegaPixels { get; set; }
    public bool HasLens { get; set; }
    public Camera(string name, int megaPixels, bool hasLens) : base(name)
    {
        MegaPixels = megaPixels;
        HasLens = hasLens;
    }
    
    public override string ToString()
    {
        return base.ToString() + " | Megapiksele: " + MegaPixels + "MP, Obiektyw: " + (HasLens ? "Tak" : "Nie");
    }
    
}