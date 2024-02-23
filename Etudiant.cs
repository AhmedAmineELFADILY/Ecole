using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole
{
    internal class Etudiant
    {

        public virtual int Id{get;set;}
        public virtual string Nom { get;set;}
        public virtual string Groupe { get;set;}

        public Etudiant(string nom, string groupe)
        {
            Nom = nom;
            Groupe = groupe;
        }
        public override string ToString()
        {
            return $"[{Id}] {Nom} {Groupe}";
        }

    }
}
