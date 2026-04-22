namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models.KovosF2;

public class KovosF2Repo : RepoBase
{
    public static List<KovaL> ListKovos()
    {
        var query = $@"
            SELECT kd.id,
                   kd.Kovos_Eile,
                   kd.Kovos_laikas_data,
                   CASE WHEN kd.Tituline_kova = 1 THEN 'Taip' ELSE 'Ne' END AS Tituline,
                   ks.name AS Statusas,
                   kd.fk_Renginys AS Renginys
            FROM `{Config.TblPrefix}Kovos_duomenys` kd
            LEFT JOIN `{Config.TblPrefix}Kovos_Statusas` ks ON ks.id = kd.Kovos_statutas
            ORDER BY kd.id DESC";

        var drc = Sql.Query(query);
        return Sql.MapAll<KovaL>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.KovosEile = dre.From<int>("Kovos_Eile");
            t.KovosLaikasData = dre.From<DateTime>("Kovos_laikas_data");
            t.TitulineKova = dre.From<string>("Tituline");
            t.Statusas = dre.From<string?>("Statusas") ?? string.Empty;
            t.Renginys = dre.From<string>("Renginys");
        });
    }

    public static KovaCE FindKovaCE(int id)
    {
        var result = new KovaCE();
        var query = $@"
            SELECT id, Kovos_Eile, Tituline_kova, Pastabos, Kovos_laikas_data, Kovos_statutas, fk_Svorio_Kategorija, fk_Renginys, fk_Kovos_Taisykles
            FROM `{Config.TblPrefix}Kovos_duomenys`
            WHERE id=?id";

        var drc = Sql.Query(query, args => args.Add("?id", id));
        var one = Sql.MapOne<KovaCE.KovaM>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.KovosEile = dre.From<int>("Kovos_Eile");
            t.TitulineKova = dre.From<bool>("Tituline_kova");
            t.Pastabos = dre.From<string?>("Pastabos");
            t.KovosLaikasData = dre.From<DateTime>("Kovos_laikas_data");
            t.KovosStatutas = dre.From<int>("Kovos_statutas");
            t.FkSvorioKategorija = dre.From<int>("fk_Svorio_Kategorija");
            t.FkRenginys = dre.From<string>("fk_Renginys");
            t.FkKovosTaisykles = dre.From<string>("fk_Kovos_Taisykles");
        });

        result.Kova = one;
        result.KovotojuDalyvavimai = ListKovotojoDalyvavimai(id);
        return result;
    }

    public static int InsertKova(KovaCE ce)
    {
        var query = $@"
            INSERT INTO `{Config.TblPrefix}Kovos_duomenys`
            (Kovos_Eile, Tituline_kova, Pastabos, Kovos_laikas_data, Kovos_statutas, fk_Svorio_Kategorija, fk_Renginys, fk_Kovos_Taisykles)
            VALUES
            (?eile, ?tituline, ?past, ?laikas, ?statusas, ?svoris, ?renginys, ?taisykles)";

        var insertedId = Sql.Insert(query, args =>
        {
            args.Add("?eile", ce.Kova.KovosEile);
            args.Add("?tituline", ce.Kova.TitulineKova);
            args.Add("?past", ce.Kova.Pastabos);
            args.Add("?laikas", ce.Kova.KovosLaikasData);
            args.Add("?statusas", ce.Kova.KovosStatutas);
            args.Add("?svoris", ce.Kova.FkSvorioKategorija);
            args.Add("?renginys", ce.Kova.FkRenginys);
            args.Add("?taisykles", ce.Kova.FkKovosTaisykles);
        });

        return Convert.ToInt32(insertedId);
    }

    public static void UpdateKova(KovaCE ce)
    {
        var query = $@"
            UPDATE `{Config.TblPrefix}Kovos_duomenys`
            SET Kovos_Eile=?eile,
                Tituline_kova=?tituline,
                Pastabos=?past,
                Kovos_laikas_data=?laikas,
                Kovos_statutas=?statusas,
                fk_Svorio_Kategorija=?svoris,
                fk_Renginys=?renginys,
                fk_Kovos_Taisykles=?taisykles
            WHERE id=?id";

        Sql.Update(query, args =>
        {
            args.Add("?id", ce.Kova.Id);
            args.Add("?eile", ce.Kova.KovosEile);
            args.Add("?tituline", ce.Kova.TitulineKova);
            args.Add("?past", ce.Kova.Pastabos);
            args.Add("?laikas", ce.Kova.KovosLaikasData);
            args.Add("?statusas", ce.Kova.KovosStatutas);
            args.Add("?svoris", ce.Kova.FkSvorioKategorija);
            args.Add("?renginys", ce.Kova.FkRenginys);
            args.Add("?taisykles", ce.Kova.FkKovosTaisykles);
        });
    }

    public static void DeleteKova(int id)
    {
        DeleteKovotojoDalyvavimai(id);
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovos_duomenys` WHERE id=?id";
        Sql.Delete(query, args => args.Add("?id", id));
    }

    public static List<KovaCE.KovotojoDalyvavimasM> ListKovotojoDalyvavimai(int kovaId)
    {
        var query = $@"
            SELECT id, Baigties_raundas, Baigties_laikas_min, Baigties_laikas_sek, Baigties_Budas, Rezultatas, fk_Kovotojai
            FROM `{Config.TblPrefix}Kovotojo_Dalyvavimas`
            WHERE fk_Kovos_duomenys=?id
            ORDER BY id";

        var drc = Sql.Query(query, args => args.Add("?id", kovaId));
        var list = Sql.MapAll<KovaCE.KovotojoDalyvavimasM>(drc, (dre, t) =>
        {
            t.FkKovotojai = dre.From<int>("fk_Kovotojai");
            t.BaigtiesRaundas = dre.From<int>("Baigties_raundas");
            t.BaigtiesLaikasMin = dre.From<int>("Baigties_laikas_min");
            t.BaigtiesLaikasSek = dre.From<int>("Baigties_laikas_sek");
            t.BaigtiesBudas = dre.From<int>("Baigties_Budas");
            t.Rezultatas = dre.From<int>("Rezultatas");
        });

        for (var i = 0; i < list.Count; i++)
            list[i].InListId = i;

        return list;
    }

    public static void ReplaceKovotojoDalyvavimai(int kovaId, IList<KovaCE.KovotojoDalyvavimasM> rows)
    {
        DeleteKovotojoDalyvavimai(kovaId);
        foreach (var row in rows)
            InsertKovotojoDalyvavimas(kovaId, row);
    }

    private static void InsertKovotojoDalyvavimas(int kovaId, KovaCE.KovotojoDalyvavimasM row)
    {
        var query = $@"
            INSERT INTO `{Config.TblPrefix}Kovotojo_Dalyvavimas`
            (Baigties_raundas, Baigties_laikas_min, Baigties_laikas_sek, Baigties_Budas, Rezultatas, fk_Kovos_duomenys, fk_Kovotojai)
            VALUES
            (?raundas, ?min, ?sek, ?budas, ?rez, ?kova, ?kovotojas)";

        Sql.Insert(query, args =>
        {
            args.Add("?raundas", row.BaigtiesRaundas);
            args.Add("?min", row.BaigtiesLaikasMin);
            args.Add("?sek", row.BaigtiesLaikasSek);
            args.Add("?budas", row.BaigtiesBudas);
            args.Add("?rez", row.Rezultatas);
            args.Add("?kova", kovaId);
            args.Add("?kovotojas", row.FkKovotojai);
        });
    }

    private static void DeleteKovotojoDalyvavimai(int kovaId)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovotojo_Dalyvavimas` WHERE fk_Kovos_duomenys=?id";
        Sql.Delete(query, args => args.Add("?id", kovaId));
    }
}



