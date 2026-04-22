namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;
using static Lab_2_DB.Models.LookUpLenteles;

public class KovosDuomenysRepo : RepoBase
{
    public static List<KovosDuomenys> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovos_duomenys` ORDER BY id DESC";
        var drc = Sql.Query(query);
        return Sql.MapAll<KovosDuomenys>(drc, (dre, t) =>
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
    }

    public static KovosDuomenys Find(int id)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovos_duomenys` WHERE id=?id";
        var drc = Sql.Query(query, args => args.Add("?id", id));
        return Sql.MapOne<KovosDuomenys>(drc, (dre, t) =>
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
    }

    public static void Insert(KovosDuomenys k)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Kovos_duomenys`
                       (Kovos_Eile, Tituline_kova, Pastabos, Kovos_laikas_data, Kovos_statutas, fk_Svorio_Kategorija, fk_Renginys, fk_Kovos_Taisykles)
                       VALUES (?eile, ?tit, ?past, ?laikas, ?stat, ?sv, ?r, ?t)";
        Sql.Insert(query, args =>
        {
            args.Add("?eile", k.KovosEile);
            args.Add("?tit", k.TitulineKova);
            args.Add("?past", k.Pastabos);
            args.Add("?laikas", k.KovosLaikasData);
            args.Add("?stat", k.KovosStatutas);
            args.Add("?sv", k.FkSvorioKategorija);
            args.Add("?r", k.FkRenginys);
            args.Add("?t", k.FkKovosTaisykles);
        });
    }

    public static void Update(KovosDuomenys k)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Kovos_duomenys`
                       SET Kovos_Eile=?eile, Tituline_kova=?tit, Pastabos=?past, Kovos_laikas_data=?laikas,
                           Kovos_statutas=?stat, fk_Svorio_Kategorija=?sv, fk_Renginys=?r, fk_Kovos_Taisykles=?t
                       WHERE id=?id";
        Sql.Update(query, args =>
        {
            args.Add("?eile", k.KovosEile);
            args.Add("?tit", k.TitulineKova);
            args.Add("?past", k.Pastabos);
            args.Add("?laikas", k.KovosLaikasData);
            args.Add("?stat", k.KovosStatutas);
            args.Add("?sv", k.FkSvorioKategorija);
            args.Add("?r", k.FkRenginys);
            args.Add("?t", k.FkKovosTaisykles);
            args.Add("?id", k.Id);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovos_duomenys` WHERE id=?id";
        Sql.Delete(query, args => args.Add("?id", id));
    }

    public static List<KovosStatusas> ListKovosStatusas() => LookUpLentelesRepo.ListKovosStatusas();
    public static List<SvorioKategorija> ListSvorioKategorija() => SvorioKategorijaRepo.List();
    public static List<Renginys> ListRenginiai() => RenginysRepo.List();
    public static List<KovosTaisykles> ListKovosTaisykles() => KovosTaisyklesRepo.List();
}



