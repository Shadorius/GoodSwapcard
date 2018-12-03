using ModelServer;
using Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodSwapcard
{
    class TestConsole
    {
        static void Main(string[] args)
        {
            RepoUtilisateur repo = new RepoUtilisateur();
            UtilisateurMS user = new UtilisateurMS();

            user = repo.Get(1);

            Console.WriteLine(user);

            Console.ReadKey();
        }
    }
}
