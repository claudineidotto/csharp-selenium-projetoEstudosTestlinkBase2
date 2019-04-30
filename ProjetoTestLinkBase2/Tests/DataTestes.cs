using NUnit.Framework;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    class DataTestes : WebDriver
    {




        [Category("DataTest"),
        TestCaseSource("Data")]
        public void CriarCamposPersonalizadosPorTipo(string tipo)
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            campospersonalizados.criarCamposPersonalizadosDataDriven(tipo);


        }


        public static List<TestCaseData> Data
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(@"C:\Repositório de projetos\TestlinkBase2\ProjetoTestLinkBase2\TestData\Teste.csv"))
                //using (var fs = File.OpenRead(SeleniumComum.SeleniumUteis.getPathDataDrivenFiles()))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        //IES, IND_EXECUTA
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ',' }, StringSplitOptions.None);
                            string tipo = split[0].Trim();
                            string ind_executa = split[1].Trim();

                            if (ind_executa.Equals("S"))
                            {
                                var testCase = new TestCaseData(tipo);
                                testCases.Add(testCase);
                            }
                        }
                    }
                }
                return testCases;
            }
        }
    }
}
