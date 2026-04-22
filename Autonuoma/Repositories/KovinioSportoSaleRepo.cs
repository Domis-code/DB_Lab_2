namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;


public class KovinioSportoSaleRepo : RepoBase
{
    public static List<KovinioSportoSale> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovinio_Sporto_sales` ORDER BY Klubo_Pavadinimas ASC";
        var drc = Sql.Query(query);

        return Sql.MapAll<KovinioSportoSale>(drc, (dre, t) =>
        {
            t.KluboPavadinimas = dre.From<string>("Klubo_Pavadinimas");
            t.Miestas = dre.From<string>("Miestas");
            t.Salis = dre.From<string>("Salis");
            t.Adresas = dre.From<string>("Adresas");
            t.TelefonoNr = dre.From<string>("Telefono_nr");
            t.OriginalPK = t.KluboPavadinimas;
        });
    }

    public static KovinioSportoSale Find(string pk)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovinio_Sporto_sales` WHERE Klubo_Pavadinimas=?pk";
        var drc = Sql.Query(query, args => { args.Add("?pk", pk); });

        return Sql.MapOne<KovinioSportoSale>(drc, (dre, t) =>
        {
            t.KluboPavadinimas = dre.From<string>("Klubo_Pavadinimas");
            t.Miestas = dre.From<string>("Miestas");
            t.Salis = dre.From<string>("Salis");
            t.Adresas = dre.From<string>("Adresas");
            t.TelefonoNr = dre.From<string>("Telefono_nr");
            t.OriginalPK = t.KluboPavadinimas;
        });
    }

    public static void Insert(KovinioSportoSale s)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Kovinio_Sporto_sales`
		               (Klubo_Pavadinimas, Miestas, Salis, Adresas, Telefono_nr)
		               VALUES (?pav, ?miestas, ?salis, ?adresas, ?tel)";
        Sql.Insert(query, args =>
        {
            args.Add("?pav", s.KluboPavadinimas);
            args.Add("?miestas", s.Miestas);
            args.Add("?salis", s.Salis);
            args.Add("?adresas", s.Adresas);
            args.Add("?tel", s.TelefonoNr);
        });
    }

    public static void Update(string originalPK, KovinioSportoSale s)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Kovinio_Sporto_sales`
		               SET Klubo_Pavadinimas=?pav, Miestas=?miestas, Salis=?salis,
		                   Adresas=?adresas, Telefono_nr=?tel
		               WHERE Klubo_Pavadinimas=?orig";
        Sql.Update(query, args =>
        {
            args.Add("?pav", s.KluboPavadinimas);
            args.Add("?miestas", s.Miestas);
            args.Add("?salis", s.Salis);
            args.Add("?adresas", s.Adresas);
            args.Add("?tel", s.TelefonoNr);
            args.Add("?orig", originalPK);
        });
    }

    public static void Delete(string pk)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovinio_Sporto_sales` WHERE Klubo_Pavadinimas=?pk";
        Sql.Delete(query, args => { args.Add("?pk", pk); });
    }
}