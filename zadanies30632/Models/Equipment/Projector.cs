namespace zadanies30632.Models.Equipment
{
    public class Projector : Equipment
    {
        public int ResolutionDpi { get; set; }
        public bool HasHdmi { get; set; }

        public Projector(string name, int resolutionDpi, bool hasHdmi) : base(name)
        {
            ResolutionDpi = resolutionDpi;
            HasHdmi = hasHdmi;
        }

        public override string ToString()
        {
            return base.ToString() + " | Rozdzielczosc: " + ResolutionDpi + "DPI, HDMI: " + (HasHdmi ? "Tak" : "Nie");
        }
    }
}