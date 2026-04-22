namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;


public class TrenerisRepo : RepoBase
{
    public static List<Treneris> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Treneriai` ORDER BY id DESC";
        var drc = Sql.Query(query);

        return Sql.MapAll<Treneris>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.Vardas = dre.From<string>("Vardas");
            t.Pavarde = dre.From<string>("Pavarde");
            t.Specializacija = dre.From<string>("Specializacija");
            t.Pareigos = dre.From<string>("Pareigos");
            t.PatirtisMetais = dre.From<int>("Patirtis_metais");
            t.FkKovinioSportoSale = dre.From<string>("fk_Kovinio_Sporto_sales");
        });
    }

    public static Treneris Find(int id)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Treneriai` WHERE id=?id";
        var drc = Sql.Query(query, args => { args.Add("?id", id); });

        return Sql.MapOne<Treneris>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.Vardas = dre.From<string>("Vardas");
            t.Pavarde = dre.From<string>("Pavarde");
            t.Specializacija = dre.From<string>("Specializacija");
            t.Pareigos = dre.From<string>("Pareigos");
            t.PatirtisMetais = dre.From<int>("Patirtis_metais");
            t.FkKovinioSportoSale = dre.From<string>("fk_Kovinio_Sporto_sales");
        });
    }

    public static void Insert(Treneris t)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Treneriai`
		               (Vardas, Pavarde, Specializacija, Pareigos, Patirtis_metais, fk_Kovinio_Sporto_sales)
		               VALUES (?vardas, ?pavarde, ?spec, ?par, ?pat, ?sale)";
        Sql.Insert(query, args =>
        {
            args.Add("?vardas", t.Vardas);
            args.Add("?pavarde", t.Pavarde);
            args.Add("?spec", t.Specializacija);
            args.Add("?par", t.Pareigos);
            args.Add("?pat", t.PatirtisMetais);
            args.Add("?sale", t.FkKovinioSportoSale);
        });
    }

    public static void Update(Treneris t)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Treneriai`
		               SET Vardas=?vardas, Pavarde=?pavarde, Specializacija=?spec,
		                   Pareigos=?par, Patirtis_metais=?pat, fk_Kovinio_Sporto_sales=?sale
		               WHERE id=?id";
        Sql.Update(query, args =>
        {
            args.Add("?vardas", t.Vardas);
            args.Add("?pavarde", t.Pavarde);
            args.Add("?spec", t.Specializacija);
            args.Add("?par", t.Pareigos);
            args.Add("?pat", t.PatirtisMetais);
            args.Add("?sale", t.FkKovinioSportoSale);
            args.Add("?id", t.Id);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Treneriai` WHERE id=?id";
        Sql.Delete(query, args => { args.Add("?id", id); });
    }
}