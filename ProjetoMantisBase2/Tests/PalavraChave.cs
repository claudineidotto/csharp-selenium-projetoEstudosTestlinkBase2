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

namespace ProjetoMantisBase2.Tests
{
    class PalavraChave:WebDriver

    {
        [Category ("Palavra Chave"), Test]

        public void CriarPalavraChave()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PalavraChavePageObjects palavrachave = new PalavraChavePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPalavraChave();
            palavrachave.CriarPalavraChave();
        }
        [Category("Palavra Chave"), Test]
        public void DeletarPalavraChave()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PalavraChavePageObjects palavrachave = new PalavraChavePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPalavraChave();
            palavrachave.DeletarPalavraChave();
        }
    }
}
