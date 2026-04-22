using static Lab_2_DB.Models.LookUpLenteles;

namespace Lab_2_DB.Repositories
{
    public class LookUpLentelesRepo : RepoBase
    {
        public static List<Lytis> ListLytis()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Lytis` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<Lytis>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<KovosStatusas> ListKovosStatusas()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Kovos_Statusas` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<KovosStatusas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<KovosPabaigosTipas> ListKovosPabaigosTipai()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Kovos_Pabaigos_Tipai` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<KovosPabaigosTipas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<KovosTaisykliuTipas> ListKovosTaisykliuTipai()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Kovos_Taisykliu_tipai` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<KovosTaisykliuTipas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<LaimejimoRezultatas> ListLaimejimoRezultatas()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Laimejimo_Rezultatas` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<LaimejimoRezultatas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<NarystesTipas> ListNarystesTipai()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Narystes_tipai` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<NarystesTipas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<StatusoTipas> ListStatusoTipai()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Statuso_tipai` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<StatusoTipas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }

        public static List<TaskuSistema> ListTaskuSistema()
        {
            var query = $@"SELECT id, name FROM `{Config.TblPrefix}Tasku_sistema` ORDER BY id ASC";
            var drc = Sql.Query(query);
            return Sql.MapAll<TaskuSistema>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Name = dre.From<string>("name");
            });
        }
    }
}
