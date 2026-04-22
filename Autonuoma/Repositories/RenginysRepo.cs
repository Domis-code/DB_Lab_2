namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;


public class RenginysRepo : RepoBase
{
    public static List<Renginys> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Renginys` ORDER BY Renginio_Data DESC";
        var drc = Sql.Query(query);

        return Sql.MapAll<Renginys>(drc, (dre, t) =>
        {
            t.RenginioPavadinimas = dre.From<string>("Renginio_Pavadinimas");
            t.RenginioData = dre.From<DateTime>("Renginio_Data");
            t.VietaAdresas = dre.From<string>("Vieta_adresas");
            t.Miestas = dre.From<string>("Miestas");
            t.Organizatorius = dre.From<string>("Organizatorius");
            t.OriginalPK = t.RenginioPavadinimas;
        });
    }

    public static Renginys Find(string pk)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Renginys` WHERE Renginio_Pavadinimas=?pk";
        var drc = Sql.Query(query, args => { args.Add("?pk", pk); });

        return Sql.MapOne<Renginys>(drc, (dre, t) =>
        {
            t.RenginioPavadinimas = dre.From<string>("Renginio_Pavadinimas");
            t.RenginioData = dre.From<DateTime>("Renginio_Data");
            t.VietaAdresas = dre.From<string>("Vieta_adresas");
            t.Miestas = dre.From<string>("Miestas");
            t.Organizatorius = dre.From<string>("Organizatorius");
            t.OriginalPK = t.RenginioPavadinimas;
        });
    }

    public static void Insert(Renginys r)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Renginys`
		               (Renginio_Pavadinimas, Renginio_Data, Vieta_adresas, Miestas, Organizatorius)
		               VALUES (?pav, ?data, ?vieta, ?miestas, ?org)";
        Sql.Insert(query, args =>
        {
            args.Add("?pav", r.RenginioPavadinimas);
            args.Add("?data", r.RenginioData);
            args.Add("?vieta", r.VietaAdresas);
            args.Add("?miestas", r.Miestas);
            args.Add("?org", r.Organizatorius);
        });
    }

    public static void Update(string originalPK, Renginys r)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Renginys`
		               SET Renginio_Pavadinimas=?pav, Renginio_Data=?data, Vieta_adresas=?vieta,
		                   Miestas=?miestas, Organizatorius=?org
		               WHERE Renginio_Pavadinimas=?orig";
        Sql.Update(query, args =>
        {
            args.Add("?pav", r.RenginioPavadinimas);
            args.Add("?data", r.RenginioData);
            args.Add("?vieta", r.VietaAdresas);
            args.Add("?miestas", r.Miestas);
            args.Add("?org", r.Organizatorius);
            args.Add("?orig", originalPK);
        });
    }

    public static void Delete(string pk)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Renginys` WHERE Renginio_Pavadinimas=?pk";
        Sql.Delete(query, args => { args.Add("?pk", pk); });
    }
}