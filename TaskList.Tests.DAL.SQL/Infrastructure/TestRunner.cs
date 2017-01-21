using System;
using System.Data.Entity;
using NUnit.Framework;
using Tasklist.DAL.SQL;

namespace TaskList.Tests.DAL.SQL    //must be in root namespace for SetUpFixture to be called by NUnit
{
    [SetUpFixture]
    public class TestRunner
    {
        [SetUp]
        public static void SetUp()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }
    }
}
