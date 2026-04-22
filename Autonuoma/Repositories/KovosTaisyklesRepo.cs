namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;


public class KovosTaisyklesRepo : RepoBase
{
    public static List<KovosTaisykles> List()
    {
        var query = $@"
            SELECT
                `Taisykliu_pavadinimas`,
                `Raundu_Skaičius` AS Raundu_Skaicius,
                `Raundo_Trukme_min`,
                `Kovos_Taisykles`,
                `Taskų_sistema` AS Tasku_sistema
            FROM `{Config.TblPrefix}Kovos_Taisykles`
            ORDER BY `Taisykliu_pavadinimas` ASC";
        var drc = Sql.Query(query);

        return Sql.MapAll<KovosTaisykles>(drc, (dre, t) =>
        {
            t.TaisykliuPavadinimas = dre.From<string>("Taisykliu_pavadinimas");
            t.RaunduSkaicius = dre.From<int>("Raundu_Skaicius");
            t.RaundoTrukmeMin = dre.From<int>("Raundo_Trukme_min");
            t.KovosTaisykliuTipas = dre.From<int>("Kovos_Taisykles");
            t.TaskuSistema = dre.From<int>("Tasku_sistema");
            t.OriginalPK = t.TaisykliuPavadinimas;
        });
    }

    public static KovosTaisykles Find(string pk)
    {
        var query = $@"
            SELECT
                `Taisykliu_pavadinimas`,
                `Raundu_Skaičius` AS Raundu_Skaicius,
                `Raundo_Trukme_min`,
                `Kovos_Taisykles`,
                `Taskų_sistema` AS Tasku_sistema
            FROM `{Config.TblPrefix}Kovos_Taisykles`
            WHERE `Taisykliu_pavadinimas`=?pk";
        var drc = Sql.Query(query, args => { args.Add("?pk", pk); });

        return Sql.MapOne<KovosTaisykles>(drc, (dre, t) =>
        {
            t.TaisykliuPavadinimas = dre.From<string>("Taisykliu_pavadinimas");
            t.RaunduSkaicius = dre.From<int>("Raundu_Skaicius");
            t.RaundoTrukmeMin = dre.From<int>("Raundo_Trukme_min");
            t.KovosTaisykliuTipas = dre.From<int>("Kovos_Taisykles");
            t.TaskuSistema = dre.From<int>("Tasku_sistema");
            t.OriginalPK = t.TaisykliuPavadinimas;
        });
    }

    public static void Insert(KovosTaisykles k)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Kovos_Taisykles`
		               (`Taisykliu_pavadinimas`, `Raundu_Skaičius`, `Raundo_Trukme_min`, `Kovos_Taisykles`, `Taskų_sistema`)
		               VALUES (?pav, ?rs, ?rt, ?kt, ?ts)";
        Sql.Insert(query, args =>
        {
            args.Add("?pav", k.TaisykliuPavadinimas);
            args.Add("?rs", k.RaunduSkaicius);
            args.Add("?rt", k.RaundoTrukmeMin);
            args.Add("?kt", k.KovosTaisykliuTipas);
            args.Add("?ts", k.TaskuSistema);
        });
    }

    public static void Update(string originalPK, KovosTaisykles k)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Kovos_Taisykles`
		               SET `Taisykliu_pavadinimas`=?pav, `Raundu_Skaičius`=?rs, `Raundo_Trukme_min`=?rt,
		                   `Kovos_Taisykles`=?kt, `Taskų_sistema`=?ts
		               WHERE `Taisykliu_pavadinimas`=?orig";
        Sql.Update(query, args =>
        {
            args.Add("?pav", k.TaisykliuPavadinimas);
            args.Add("?rs", k.RaunduSkaicius);
            args.Add("?rt", k.RaundoTrukmeMin);
            args.Add("?kt", k.KovosTaisykliuTipas);
            args.Add("?ts", k.TaskuSistema);
            args.Add("?orig", originalPK);
        });
    }

    public static void Delete(string pk)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovos_Taisykles` WHERE Taisykliu_pavadinimas=?pk";
        Sql.Delete(query, args => { args.Add("?pk", pk); });
    }
}