namespace Lab_2_DB.Models
{
    public class LookUpLenteles
    {
        /// <summary>
        /// 'NarystesTipai' enumerator in lists.
        /// </summary>
        public class NarystesTipas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'KovosPabaigosTipai' enumerator in lists.
        /// </summary>
        public class KovosPabaigosTipas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'KovosStatusas' enumerator in lists.
        /// </summary>
        public class KovosStatusas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'KovosTaisykliuTipai' enumerator in lists.
        /// </summary>
        public class KovosTaisykliuTipas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'LaimejimoRezultatas' enumerator in lists.
        /// </summary>
        public class LaimejimoRezultatas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'Lytis' enumerator in lists.
        /// </summary>
        public class Lytis
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'StatusoTipai' enumerator in lists.
        /// </summary>
        public class StatusoTipas
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        /// <summary>
        /// 'TaskuSistema' enumerator in lists.
        /// </summary>
        public class TaskuSistema
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }
    }
}

