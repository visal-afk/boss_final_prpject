namespace boss.CV;

public class Cv
{

    public int id { get; set; }
    public string ixtisas { get; set; }
    public string mekteb { get; set; }
    public int unoversitetbal { get; set; }
    public List<string> bacariqlar { get; set; } = new List<string>();
    public List<string> companies { get; set; } = new List<string>();
    public int isebaslamaqintarixi { get; set; }
    public int isibitmeTarixi { get; set; }
    public List<string> diler { get; set; } = new List<string>();
    public bool Fdiplom { get; set; }
    public string gitlink { get; set; }
    public string linkedin { get; set; }

   
    public Cv() { }

 
    public Cv(string ixtisas, string mekteb, int unoversitetbal, List<string> bacariqlar,
              List<string> companies, int isebaslamaqintarixi, int isibitmeTarixi,
              List<string> diler, bool fdiplom, string gitlink, string linkedin)
    {
        this.ixtisas = ixtisas;
        this.mekteb = mekteb;
        this.unoversitetbal = unoversitetbal;
        this.bacariqlar = bacariqlar;
        this.companies = companies;
        this.isebaslamaqintarixi = isebaslamaqintarixi;
        this.isibitmeTarixi = isibitmeTarixi;
        this.diler = diler;
        this.Fdiplom = fdiplom;
        this.gitlink = gitlink;
        this.linkedin = linkedin;
    }
}