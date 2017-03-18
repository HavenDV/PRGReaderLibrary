namespace PRGReaderLibrary.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PRGReader_Tests
    {
        private string GetFullPath(string filename) => 
            System.IO.Path.Combine("../../TestFiles", filename);

        [TestMethod]
        public void Read_Asy1()
        {
            var prg = PRG.Load(GetFullPath("asy1.prg"));

            Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_Balsam2()
        {
            //var prg = PRG.Load(GetFullPath("balsam2.prg"));

            //Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_Panel1()
        {
            var prg = PRG.Load(GetFullPath("panel1.prg"));

            Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_Panel11()
        {
            var prg = PRG.Load(GetFullPath("panel11.prg"));

            Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_Panel2()
        {
            var prg = PRG.Load(GetFullPath("panel2.prg"));

            Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_Temco()
        {
            var prg = PRG.Load(GetFullPath("temco.prg"));

            Console.WriteLine(prg.GetInfoString());
        }

        [TestMethod]
        public void Read_SelfTestRev3()
        {
            //var prg = PRG.Load(GetFullPath("SelfTestRev3.prg"));

            //Console.WriteLine(prg.GetInfoString());
        }
    }
}
