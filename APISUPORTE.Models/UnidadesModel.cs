//using Amazon.Runtime.Internal.Util;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace APISUPORTE.Models
//{
//    public class UnidadesModel
//    {
//        private string[] guadalajara = new string[2];

//        private string[] irapuato = new string[2];

//        private string[] la_Presa = new string[2];

//        private string[] los_Reyes = new string[2];

//        private string[] monterrey = new string[2];

//        private string[] sahagun = new string[2];

//        private string[] san_juan = new string[2];

//        private string[] tultitlan = new string[2];

//        private string[] veracruz = new string[2];

//        private string[] local = new string[2];

//        private string[] teste = new string[2];

//        public string[] Guadalajara { get => guadalajara; set => guadalajara = value; }

//        public string[] Irapuato { get => irapuato; set => irapuato = value; }

//        public string[] La_Presa { get => la_Presa; set => la_Presa = value; }

//        public string[] Los_Reyes { get => los_Reyes; set => los_Reyes = value; }

//        public string[] Monterrey { get => monterrey; set => monterrey = value; }

//        public string[] Sahagun { get => sahagun; set => sahagun = value; }

//        public string[] San_juan { get => san_juan; set => san_juan = value; }

//        public string[] Tultitlan { get => tultitlan; set => tultitlan = value; }

//        public string[] Veracruz { get => veracruz; set => veracruz = value; }
//        public string[] Ticuman { get; private set; }
//        public string[] Local { get => local; set => local = value; }

//        public string[] Teste { get => teste; set => teste = value; }

//        private string strCoon = string.Empty;
//        public UnidadesModel()
//        {



//            this.Guadalajara = new string[] { "1", "10.50.198.40" };
//            this.Irapuato = new string[] { "2", "10.50.61.81" };
//            this.La_Presa = new string[] { "3", "10.88.1.30" };
//            this.Los_Reyes = new string[] { "4", "10.50.197.21" };
//            this.Monterrey = new string[] { "5", "10.50.65.81" };
//            this.Sahagun = new string[] { "6", "10.84.30.19" };
//            this.San_juan = new string[] { "7", "10.50.47.11" };
//            this.Tultitlan = new string[] { "8", "10.83.10.76" };
//            this.Veracruz = new string[] { "9", "10.50.196.40" };
//            this.Ticuman = new string[] { "10", "10.79.14.20" };
//            //this.Local          = new string [] { "awkbf6kgjds", "NEPRE0004\\GSCSLOCAL" };
//            this.Local = new string[] { "11", "192.168.15.50" };
//            this.Teste = new string[] { "12", @"10.79.14.20\testedev" };
//            //this.Teste = new string[] { "awkbf6kgjds", "10.79.14.20" };

//            //this.Guadalajara = new string[] { "pkb346jb5l3", "10.79.14.20" };
//            //this.Irapuato = new string[] { "dgt768jk908", "10.79.14.20" };
//            //this.La_Presa = new string[] { "bng435hj132", "10.79.14.20" };
//            //this.Los_Reyes = new string[] { "lkh267bh258", "10.79.14.20" };
//            //this.Monterrey = new string[] { "jbg963op217", "10.79.14.20" };
//            //this.Sahagun = new string[] { "klm987tr236", "10.79.14.20" };
//            //this.San_juan = new string[] { "uhn546bv258", "10.79.14.20" };
//            //this.Tultitlan = new string[] { "rte852rq374", "10.79.14.20" };
//            //this.Veracruz = new string[] { "wxj873zt741", "10.79.14.20" };
//            //this.Teste = new string[] { "awkbf6kgjds", "NEPRE0004\\GSCSLOCAL" };
//            //this.Local = new string[] { "tyu009bh376", "NEPRE0004\\GSCSLOCAL" };
//            //this.Teste = new string[] { "awkbf6kgjds", "10.79.14.20" };
//        }
//        public List<string> construtor_string(string ini)
//        {
//            var MyIni = new IniFile(ini);
//            List<string> Unidades = new List<string>();

//            int numServer = Convert.ToInt32(MyIni.IniReadValue("UNIDADES", "NUMSERVERS"));
//            for (int i = 0; i <= numServer; i++)
//            {
//                Unidades.Add(MyIni.IniReadValue("UNIDADES", "SERVER" + i));
//            }


//            return Unidades;
//        }

//        public List<string> construtor_stringPaises(string ini)
//        {
//            var MyIni = new IniFile(ini);
//            List<string> Paises = new List<string>();

//            int numPaises = Convert.ToInt32(MyIni.IniReadValue("PAISES", "NUMPAISES"));
//            for (int i = 0; i < numPaises; i++)
//            {
//                Paises.Add(MyIni.IniReadValue("PAISES", "PAIS" + i));
//            }


//            return Paises;
//        }
//        public string retornaIPUnoidade(string ipUnidade)
//        {
//            List<string> Unidades = new List<string>();
//            Unidades = construtor_string(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "//conf.ini");
//            string ipDeRetorno = "";

//            foreach (string s in Unidades)
//            {
//                string cod = s.Split(',')[0].ToString();
//                string ip = s.Split(',')[1].ToString();
//                if (cod == ipUnidade)
//                {
//                    ipDeRetorno = ip;
//                }
//            }
//            //switch (ipUnidade)
//            //{
//            //    case "pkb346jb5l3":
//            //        ipDeRetorno = Guadalajara[1];
//            //        break;
//            //    case "dgt768jk908":
//            //        ipDeRetorno = Irapuato[1];
//            //        break;
//            //    case "bng435hj132":
//            //        ipDeRetorno = La_Presa[1];
//            //        break;
//            //    case "lkh267bh258":
//            //        ipDeRetorno = Los_Reyes[1];
//            //        break;
//            //    case "jbg963op217":
//            //        ipDeRetorno = Monterrey[1];
//            //        break;
//            //    case "klm987tr236":
//            //        ipDeRetorno = Sahagun[1];
//            //        break;
//            //    case "uhn546bv258":
//            //        ipDeRetorno = San_juan[1];
//            //        break;
//            //    case "rte852rq374":
//            //        ipDeRetorno = Tultitlan[1];
//            //        break;
//            //    case "wxj873zt741":
//            //        ipDeRetorno = Veracruz[1];
//            //        break;
//            //    case "tyu009bh376":
//            //        ipDeRetorno = Local[1];
//            //        break;
//            //    case "awkbf6kgjds":
//            //        ipDeRetorno = Teste[1];
//            //        break;

//            //}
//            return ipDeRetorno;
//        }
//    }
//}
//}
