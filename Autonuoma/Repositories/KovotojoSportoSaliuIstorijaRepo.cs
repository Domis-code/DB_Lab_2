namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;

public class KovotojoSportoSaliuIstorijaRepo : RepoBase
{
    public static List<KovotojoSportoSaliuIstorija> List()
    {
        var query = $@"
            SELECT ksi.*,
                   CONCAT(k.Vardas, ' ', k.Pavarde) AS KovotojoVardasPavarde,
                   s.Klubo_Pavadinimas AS SportoSalesPavadinimas,
                   nt.name AS NarystesTipoPavadinimas,
                   st.name AS StatusoPavadinimas
            FROM `{Config.TblPrefix}Kovotojo_sporto_saliu_istorija` ksi
            LEFT JOIN `{Config.TblPrefix}Kovotojai` k ON k.id = ksi.fk_Kovotojai
            LEFT JOIN `{Config.TblPrefix}Kovinio_Sporto_sales` s ON s.Klubo_Pavadinimas = ksi.fk_Kovinio_Sporto_sales
            LEFT JOIN `{Config.TblPrefix}Narystes_tipai` nt ON nt.id = ksi.Narystes_tipas
            LEFT JOIN `{Config.TblPrefix}Statuso_tipai` st ON st.id = ksi.Statusas
            ORDER BY ksi.id DESC";
        var drc = Sql.Query(query);
        return Sql.MapAll<KovotojoSportoSaliuIstorija>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.NarystesPradzia = dre.From<DateTime>("Narystes_Pradzia");
            t.NarystesPabaiga = dre.From<DateTime>("Narystes_Pabaiga");
            t.Pastabos = dre.From<string?>("Pastabos");
            t.NarystesTipas = dre.From<int>("Narystes_tipas");
            t.Statusas = dre.From<int?>("Statusas");
            t.FkKovotojai = dre.From<int>("fk_Kovotojai");
            t.FkKovinioSportoSales = dre.From<string>("fk_Kovinio_Sporto_sales");
            t.KovotojoVardasPavarde = dre.From<string?>("KovotojoVardasPavarde");
            t.SportoSalesPavadinimas = dre.From<string?>("SportoSalesPavadinimas");
            t.NarystesTipoPavadinimas = dre.From<string?>("NarystesTipoPavadinimas");
            t.StatusoPavadinimas = dre.From<string?>("StatusoPavadinimas");
        });
    }

    public static KovotojoSportoSaliuIstorija Find(int id)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}Kovotojo_sporto_saliu_istorija` WHERE id=?id";
        var drc = Sql.Query(query, args => args.Add("?id", id));
        return Sql.MapOne<KovotojoSportoSaliuIstorija>(drc, (dre, t) =>
        {
            t.Id = dre.From<int>("id");
            t.NarystesPradzia = dre.From<DateTime>("Narystes_Pradzia");
            t.NarystesPabaiga = dre.From<DateTime>("Narystes_Pabaiga");
            t.Pastabos = dre.From<string?>("Pastabos");
            t.NarystesTipas = dre.From<int>("Narystes_tipas");
            t.Statusas = dre.From<int?>("Statusas");
            t.FkKovotojai = dre.From<int>("fk_Kovotojai");
            t.FkKovinioSportoSales = dre.From<string>("fk_Kovinio_Sporto_sales");
        });
    }

    public static void Insert(KovotojoSportoSaliuIstorija i)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}Kovotojo_sporto_saliu_istorija`
                       (Narystes_Pradzia, Narystes_Pabaiga, Pastabos, Narystes_tipas, Statusas, fk_Kovotojai, fk_Kovinio_Sporto_sales)
                       VALUES (?pr, ?pb, ?past, ?nt, ?st, ?kov, ?sale)";
        Sql.Insert(query, args =>
        {
            args.Add("?pr", i.NarystesPradzia);
            args.Add("?pb", i.NarystesPabaiga);
            args.Add("?past", i.Pastabos);
            args.Add("?nt", i.NarystesTipas);
            args.Add("?st", i.Statusas);
            args.Add("?kov", i.FkKovotojai);
            args.Add("?sale", i.FkKovinioSportoSales);
        });
    }

    public static void Update(KovotojoSportoSaliuIstorija i)
    {
        var query = $@"UPDATE `{Config.TblPrefix}Kovotojo_sporto_saliu_istorija`
                       SET Narystes_Pradzia=?pr, Narystes_Pabaiga=?pb, Pastabos=?past, Narystes_tipas=?nt,
                           Statusas=?st, fk_Kovotojai=?kov, fk_Kovinio_Sporto_sales=?sale
                       WHERE id=?id";
        Sql.Update(query, args =>
        {
            args.Add("?pr", i.NarystesPradzia);
            args.Add("?pb", i.NarystesPabaiga);
            args.Add("?past", i.Pastabos);
            args.Add("?nt", i.NarystesTipas);
            args.Add("?st", i.Statusas);
            args.Add("?kov", i.FkKovotojai);
            args.Add("?sale", i.FkKovinioSportoSales);
            args.Add("?id", i.Id);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}Kovotojo_sporto_saliu_istorija` WHERE id=?id";
        Sql.Delete(query, args => args.Add("?id", id));
    }

    public static List<LookUpLenteles.NarystesTipas> ListNarystesTipai() => LookUpLentelesRepo.ListNarystesTipai();
    public static List<LookUpLenteles.StatusoTipas> ListStatusoTipai() => LookUpLentelesRepo.ListStatusoTipai();
    public static List<Kovotojas> ListKovotojai() => KovotojasRepo.List();
    public static List<KovinioSportoSale> ListSportoSales() => KovinioSportoSaleRepo.List();
}



