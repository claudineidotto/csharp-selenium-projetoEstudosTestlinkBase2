using NUnit.Framework;
using ProjetoMantisBase2.PageObjects;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    class Baselines :WebDriver
    {

        [Category("Baselines"), Test]
        public void CriarBaseline()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            BaselinesPageObjects baselines = new BaselinesPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoBaseline();
            baselines.CriarBaseline();
        }

        [Category("Baselines"), Test]
        public void DeletarBaseline()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            BaselinesPageObjects baselines = new BaselinesPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoBaseline();
            baselines.DeletarBaseline();

        }
        [Category("Baselines"), Test]
        public void EditarBaseline()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            BaselinesPageObjects baselines = new BaselinesPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoBaseline();
            baselines.EditarBaseline();

        }
    }
}
