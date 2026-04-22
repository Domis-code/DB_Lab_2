namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;


public class SvorioKategorijaRepo : RepoBase
{
    public static List<SvorioKategorija> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Svorio_Kategorija` ORDER BY Sporto_Saka ASC, Min_kg ASC";
        var drc = Sql.Query(query);

        return Sql.MapAll<SvorioKategorija>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.SportoSaka = dre.From<string>("Sporto_Saka");
            t.KategorijosPavadinimas = dre.From<string>("Kategorijos_Pavadinimas");
            t.MinKg = dre.From<decimal>("Min_kg");
            t.MaxKg = dre.From<decimal>("Max_kg");
            t.AmziausGrupe = dre.From<int>("Amziaus_Grupe");
            t.LytiesGrupe = dre.From<int>("Lyties_Grupe");
        });
    }

    public static SvorioKategorija Find(int id)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Svorio_Kategorija` WHERE id=?id";
        var drc = Sql.Query(query, args => { args.Add("?id", id); });

        return Sql.MapOne<SvorioKategorija>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.SportoSaka = dre.From<string>("Sporto_Saka");
            t.KategorijosPavadinimas = dre.From<string>("Kategorijos_Pavadinimas");
            t.MinKg = dre.From<decimal>("Min_kg");
            t.MaxKg = dre.From<decimal>("Max_kg");
            t.AmziausGrupe = dre.From<int>("Amziaus_Grupe");
            t.LytiesGrupe = dre.From<int>("Lyties_Grupe");
        });
    }

    public static void Insert(SvorioKategorija s)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Svorio_Kategorija`
		               (Sporto_Saka, Kategorijos_Pavadinimas, Min_kg, Max_kg, Amziaus_Grupe, Lyties_Grupe)
		               VALUES (?saka, ?pav, ?min, ?max, ?amz, ?lyt)";
        Sql.Insert(query, args =>
        {
            args.Add("?saka", s.SportoSaka);
            args.Add("?pav", s.KategorijosPavadinimas);
            args.Add("?min", s.MinKg);
            args.Add("?max", s.MaxKg);
            args.Add("?amz", s.AmziausGrupe);
            args.Add("?lyt", s.LytiesGrupe);
        });
    }

    public static void Update(SvorioKategorija s)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Svorio_Kategorija`
		               SET Sporto_Saka=?saka, Kategorijos_Pavadinimas=?pav, Min_kg=?min, Max_kg=?max,
		                   Amziaus_Grupe=?amz, Lyties_Grupe=?lyt
		               WHERE id=?id";
        Sql.Update(query, args =>
        {
            args.Add("?saka", s.SportoSaka);
            args.Add("?pav", s.KategorijosPavadinimas);
            args.Add("?min", s.MinKg);
            args.Add("?max", s.MaxKg);
            args.Add("?amz", s.AmziausGrupe);
            args.Add("?lyt", s.LytiesGrupe);
            args.Add("?id", s.Id);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Svorio_Kategorija` WHERE id=?id";
        Sql.Delete(query, args => { args.Add("?id", id); });
    }
}