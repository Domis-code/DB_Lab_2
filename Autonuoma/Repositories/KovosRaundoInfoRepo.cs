namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;
using static Lab_2_DB.Models.LookUpLenteles;

public class KovosRaundoInfoRepo : RepoBase
{
    public static List<KovosRaundoInfo> List()
    {
        var query = $@"
            SELECT kri.*,
                   CONCAT('Kova #', kd.id, ' (', kd.fk_Renginys, ')') AS KovosPavadinimas,
                   kpt.name AS RaundoPabaigaPavadinimas
            FROM `{Config.TblPrefix}Kovos_raundo_info` kri
            LEFT JOIN `{Config.TblPrefix}Kovos_duomenys` kd ON kd.id = kri.fk_Kovos_duomenys
            LEFT JOIN `{Config.TblPrefix}Kovos_Pabaigos_Tipai` kpt ON kpt.id = kri.Raundo_Pabaiga
            ORDER BY kri.id DESC";
        var drc = Sql.Query(query);
        return Sql.MapAll<KovosRaundoInfo>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.RaundoNumeris = dre.From<int>("Raundo_Numeris");
            t.RaundoTrukmeMin = dre.From<int?>("Raundo_Trukme_min");
            t.RaundoTrukmeSek = dre.From<int>("Raundo_Trukme_sek");
            t.Pastabos = dre.From<string?>("Pastabos");
            t.RaundoPabaiga = dre.From<int>("Raundo_Pabaiga");
            t.RaundoPabaigaPavadinimas = dre.From<string?>("RaundoPabaigaPavadinimas");
            t.FkKovosDuomenys = dre.From<int>("fk_Kovos_duomenys");
            t.KovosPavadinimas = dre.From<string?>("KovosPavadinimas");
        });
    }

    public static KovosRaundoInfo Find(int id)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovos_raundo_info` WHERE id=?id";
        var drc = Sql.Query(query, args => args.Add("?id", id));
        return Sql.MapOne<KovosRaundoInfo>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.RaundoNumeris = dre.From<int>("Raundo_Numeris");
            t.RaundoTrukmeMin = dre.From<int?>("Raundo_Trukme_min");
            t.RaundoTrukmeSek = dre.From<int>("Raundo_Trukme_sek");
            t.Pastabos = dre.From<string?>("Pastabos");
            t.RaundoPabaiga = dre.From<int>("Raundo_Pabaiga");
            t.FkKovosDuomenys = dre.From<int>("fk_Kovos_duomenys");
        });
    }

    public static void Insert(KovosRaundoInfo r)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Kovos_raundo_info`
                       (id, Raundo_Numeris, Raundo_Trukme_min, Raundo_Trukme_sek, Pastabos, Raundo_Pabaiga, fk_Kovos_duomenys)
                       VALUES (?id, ?nr, ?min, ?sek, ?past, ?pb, ?kova)";
        Sql.Insert(query, args =>
        {
            args.Add("?id", NextId("Kovos_raundo_info"));
            args.Add("?nr", r.RaundoNumeris);
            args.Add("?min", r.RaundoTrukmeMin);
            args.Add("?sek", r.RaundoTrukmeSek);
            args.Add("?past", r.Pastabos);
            args.Add("?pb", r.RaundoPabaiga);
            args.Add("?kova", r.FkKovosDuomenys);
        });
    }

    public static void Update(KovosRaundoInfo r)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Kovos_raundo_info`
                       SET Raundo_Numeris=?nr, Raundo_Trukme_min=?min, Raundo_Trukme_sek=?sek,
                           Pastabos=?past, Raundo_Pabaiga=?pb, fk_Kovos_duomenys=?kova
                       WHERE id=?id";
        Sql.Update(query, args =>
        {
            args.Add("?nr", r.RaundoNumeris);
            args.Add("?min", r.RaundoTrukmeMin);
            args.Add("?sek", r.RaundoTrukmeSek);
            args.Add("?past", r.Pastabos);
            args.Add("?pb", r.RaundoPabaiga);
            args.Add("?kova", r.FkKovosDuomenys);
            args.Add("?id", r.Id);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovos_raundo_info` WHERE id=?id";
        Sql.Delete(query, args => args.Add("?id", id));
    }

    public static List<KovosPabaigosTipas> ListRaundoPabaigosTipai() => LookUpLentelesRepo.ListKovosPabaigosTipai();
    public static List<KovosDuomenys> ListKovos() => KovosDuomenysRepo.List();
}



