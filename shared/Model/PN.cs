using System.Reflection.Metadata.Ecma335;

namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen) {
        // TODO: Implement! 
        if (givesDen != null)
        {
            antalEnheder++;
            dates.Add(givesDen);
            return true;
        }
        return false;
        
    }

    public override double doegnDosis() {
        // LAVET!!
        double result = 0;
        if (dates.Count() > 0)
        {


            DateTime min = dates.First().dato.Date;
            DateTime max = dates.First().dato.Date;
            foreach (var date in dates)
            {
                if (date.dato.Date < min)
                {
                    min = date.dato.Date;
                }
                if (date.dato.Date > max)
                {
                    max = date.dato.Date;
                }
            }
            var difference = (max - min).Days + 1;

             result = samletDosis() / difference; 

        }
        return result;

    }


    public override double samletDosis() {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
