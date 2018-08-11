using NUnit.Framework;
using ProjetoMantisBase2.PageObjects;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    class MyViewTests   : WebDriver
    {
        [Category("Home Page"), Test]
        public void AcessoCamposPesonalizados() {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects myview = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();
            
            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            myview.acessoCustomFields();
            
        }

    }
}
