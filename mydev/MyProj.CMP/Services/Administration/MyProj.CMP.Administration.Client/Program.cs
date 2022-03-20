using MyProj.CMP.Administration.Domain.Contracts;
using MyProj.CMP.Administration.Infrastructure;
using System;

namespace MyProj.CMP.Administration.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IAdministrationDB _db = new AdministrationDB();
        }
    }
}
