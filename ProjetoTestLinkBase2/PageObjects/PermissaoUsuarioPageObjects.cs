using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class PermissaoUsuarioPageObjects : WebDriver
    {
        public PermissaoUsuarioPageObjects()
        {
        }

        #region Mapeamento
        public IWebElement AbaUsuarios => driver.FindElement(By.LinkText("Ver Usuários"));
        public IWebElement BtnCriar => driver.FindElement(By.Name("doCreate"));
        public IWebElement TxtLogin => driver.FindElement(By.Name("login"));
        public IWebElement TxtNome => driver.FindElement(By.Name("firstName"));
        public IWebElement TxtSobrenome => driver.FindElement(By.Name("lastName"));
        public IWebElement TxtSenha => driver.FindElement(By.Id("password"));
        public IWebElement TxtEmail => driver.FindElement(By.Id("email"));
        public IWebElement CbxPerfil => driver.FindElement(By.Name("rights_id"));
        public IWebElement CbxLocalizacao => driver.FindElement(By.Name("locale"));
        public IWebElement BtnSalvar => driver.FindElement(By.Name("do_update"));
        public IWebElement CheckBox => driver.FindElement(By.Name("user_is_active"));
        public IWebElement VerPerfil => driver.FindElement(By.LinkText("Ver Perfis"));
        public IWebElement BtnCriarPerfil => driver.FindElement(By.Name("doCreate"));
        public IWebElement TxtNomePerfil => driver.FindElement(By.Name("rolename"));
        public IWebElement CheckBoxCriar => driver.FindElement(By.Name("grant[mgt_testplan_create]"));
        public IWebElement BtnSalvarPerfil => driver.FindElement(By.Name("role_mgmt"));
        public IWebElement BtnSim => driver.FindElement(By.Id("ext-gen20"));
        public IWebElement BtnDesabilitarSim => driver.FindElement(By.Id("ext-gen56")); 

        #endregion



      
        public void CriarUsuarioTesterAtivo()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();

            uteis.ClicaBotao(AbaUsuarios);
            uteis.ClicaBotao(BtnCriar);
            uteis.PreencheCampoInput(TxtLogin,nome);
            uteis.PreencheCampoInput(TxtNome,nome);
            uteis.PreencheCampoInput(TxtSobrenome,nome);
            uteis.PreencheCampoInput(TxtSenha,nome);
            uteis.PreencheCampoInput(TxtEmail,SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(CbxPerfil, "tester");
            uteis.CBClick(CbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(BtnSalvar);

        }

        public void CriarUsuarioTesterAtivo( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();

            uteis.ClicaBotao(AbaUsuarios);
            uteis.ClicaBotao(BtnCriar);
            uteis.PreencheCampoInput(TxtLogin, nome);
            uteis.PreencheCampoInput(TxtNome, nome);
            uteis.PreencheCampoInput(TxtSobrenome, nome);
            uteis.PreencheCampoInput(TxtSenha, nome);
            uteis.PreencheCampoInput(TxtEmail, SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(CbxPerfil, "tester");
            uteis.CBClick(CbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(BtnSalvar);
            

        }
        public void CriarUsuarioTesterInativo()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();

            uteis.ClicaBotao(AbaUsuarios);
            uteis.ClicaBotao(BtnCriar);
            uteis.PreencheCampoInput(TxtLogin, nome);
            uteis.PreencheCampoInput(TxtNome, nome);
            uteis.PreencheCampoInput(TxtSobrenome, nome);
            uteis.PreencheCampoInput(TxtSenha, nome);
            uteis.PreencheCampoInput(TxtEmail, SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(CbxPerfil, "tester");
            uteis.CBClick(CbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(CheckBox);
            uteis.ClicaBotao(BtnSalvar);

        }

        public void DesabilitarUsuarioTester()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarUsuarioTesterAtivo(nome);
            DesabilitarUsuario(nome);
            uteis.ClicaBotao(BtnDesabilitarSim);
            Assert.AreEqual("Usuário "+nome+ " foi desabilitado com sucesso", driver.FindElement(By.CssSelector("p")).Text);
        }
        public void AtivarUsuarioDesabilitadoUsuarioTester()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarUsuarioTesterAtivo(nome);
            DesabilitarUsuario(nome);
            uteis.ClicaBotao(BtnDesabilitarSim);
            Assert.AreEqual("Usuário " + nome + " foi desabilitado com sucesso", driver.FindElement(By.CssSelector("p")).Text);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            uteis.ClicaBotao(CheckBox);
            uteis.ClicaBotao(BtnSalvar);
            uteis.VerificarElementoTabela(nome);

        }
        public void CriarPerfil()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.PreencheCampoInput(TxtNomePerfil,nome);
            uteis.ClicaBotao(CheckBoxCriar);
            uteis.ClicaBotao(BtnSalvarPerfil);
            uteis.VerificaNomeTabela(nome);
        }
        public void CriarPerfil( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.PreencheCampoInput(TxtNomePerfil, nome);
            uteis.ClicaBotao(CheckBoxCriar);
            uteis.ClicaBotao(BtnSalvarPerfil);
            uteis.VerificaNomeTabela(nome);
        }
        public void DeletarPerfil()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPerfil(nome);
            ExcluiPerfil(nome);
            uteis.ConfirmaExclusaoTabela(nome);

        }
        public void CriarPerfilSemPermissao()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.PreencheCampoInput(TxtNomePerfil, nome);
            uteis.ClicaBotao(BtnSalvarPerfil);
            Assert.AreEqual("Você não pode gravar regras sem nenhuma permissão!", driver.FindElement(By.Id("ext-gen28")).Text);

        }

        public void ExcluiPerfil(string nome )
        {
            
                SeleniumUteis uteis = new SeleniumUteis();
                WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
                espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
                var tabela = driver.FindElement(By.TagName("tbody"));
                foreach (var tr in tabela.FindElements(By.TagName("tr")))
                {
                    var tds = tr.FindElements(By.TagName("td"));
                    if (tds[0].Text.Trim().Equals(nome))
                    {
                        tds[2].FindElement(By.TagName("img")).Click();
                        uteis.ClicaBotao(BtnSim);
                        return;
                    }
                    //fim for 1

                }//fim foreach
            
        }

        public void DesabilitarUsuario(String nome)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.Id("ext-gen19")));
            var tabela = driver.FindElement(By.Id("ext-gen19"));

            foreach (var table in tabela.FindElements(By.TagName("table")))
            {
                var tr = table.FindElements(By.TagName("tr"));
                if (tr[0].Text.ToString().Contains(nome)) {
                    var tds = table.FindElements(By.TagName("td"));
                    if (tds[0].Text.Equals(nome))
                    {
                        var td = tds[7].FindElement(By.TagName("img"));
                        td.Click();
                        return;
                    }
                }
            }
        }


       

    }
}
