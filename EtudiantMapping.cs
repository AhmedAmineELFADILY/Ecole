using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole
{
    internal class EtudiantMapping : ClassMapping<Etudiant>
    {
        public EtudiantMapping() {
            Id(x => x.Id, c =>
            {
                c.Generator(Generators.Identity);
                c.Type(NHibernateUtil.Int32);
                c.Column("ID");
                c.UnsavedValue(0);
            });
            Property(x => x.Nom, c =>
            {
                c.Type(NHibernateUtil.AnsiString);
                c.NotNullable(true);
                c.Column("Nom");

            }); 
            Property(x => x.Groupe, c =>
            {
                c.Type(NHibernateUtil.AnsiString);
                c.NotNullable(true);
                c.Column("Groupe");

            });

            Table("Etudiant");

        }
    }
}
