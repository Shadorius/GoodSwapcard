﻿using ModelServer;
using Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {

        // Jerem
        static void Main(string[] args)
        {
            RepoUtilisateur repo = new RepoUtilisateur();
            UtilisateurMS user = new UtilisateurMS();

            user = repo.Get(1);

            Console.WriteLine(user.Email);
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.Phone);
            Console.WriteLine(user.Birthdate);


            Console.ReadKey();
        }

        //Axel
        //static void Main(string[] args)
        //{


        //    Console.ReadKey();
        //}

        //Geoffroy
        //static void Main(string[] args)
        //{


        //    Console.ReadKey();
        //}

    }
}
