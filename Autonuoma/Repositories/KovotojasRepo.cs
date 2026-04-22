using Lab_2_DB.Models;

namespace Lab_2_DB.Repositories
{
    public class KovotojasRepo :RepoBase
    {
        public static List<Kovotojas> List()
        {
            var query = $@"SELECT * FROM `{Config.TblPrefix}Kovotojai` ORDER BY id DESC";
            var dcr = Sql.Query(query);
            return Sql.MapAll<Kovotojas>(dcr, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Vardas = dre.From<string>("Vardas");
                t.Pavarde = dre.From<string>("Pavarde");
                t.GimimoData = dre.From<DateTime>("Gimimo_metai");
                t.SvorisKg = dre.From<decimal>("Svoris_kg");
                t.UgisCm = dre.From<int>("Ugis_cm");
            });
        }
        public static Kovotojas Find(int id)
        {
            var query = $@"SELECT * FROM `{Config.TblPrefix}Kovotojai` WHERE id=?id";
            var drc = Sql.Query(query, args => { args.Add("?id", id); });

            return Sql.MapOne<Kovotojas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Vardas = dre.From<string>("Vardas");
                t.Pavarde = dre.From<string>("Pavarde");
                t.GimimoData = dre.From<DateTime>("Gimimo_metai");
                t.SvorisKg = dre.From<decimal>("Svoris_kg");
                t.UgisCm = dre.From<int>("Ugis_cm");
            });
        }

        public static void Insert(Kovotojas k)
        {
            var query = $@"INSERT INTO`{Config.TblPrefix}Kovotojai`(Vardas,Pavarde,Gimimo_metai,Svoris_kg,Ugis_cm) VALUES(?vardas,?pavarde,?gm,?svoris,?ugis)";
            Sql.Insert(query, args =>
            {
                args.Add("?vardas", k.Vardas);
                args.Add("?pavarde", k.Pavarde);
                args.Add("?gm", k.GimimoData);
                args.Add("?svoris", k.SvorisKg);
                args.Add("?ugis", k.UgisCm);
            });
        }

        public static void Update(Kovotojas k)
        {
            var query = $@"UPDATE`{Config.TblPrefix}Kovotojai` SET Vardas=?vardas,Pavarde=?pavarde,Gimimo_metai=?gm,Svoris_kg=?svoris,Ugis_cm=?ugis Where id=?id";
            Sql.Update(query, args =>
            {
                args.Add("?vardas", k.Vardas);
                args.Add("?pavarde", k.Pavarde);
                args.Add("?gm", k.GimimoData);
                args.Add("?svoris", k.SvorisKg);
                args.Add("?ugis", k.UgisCm);
                args.Add("?id", k.Id);
            });
        }
        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `{Config.TblPrefix}Kovotojai` WHERE id=?id";
            Sql.Delete(query, args => { args.Add("?id", id); });
        }
    }
}
