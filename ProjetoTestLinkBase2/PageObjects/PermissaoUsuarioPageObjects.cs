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
        public IWebElement abaUsuarios => driver.FindElement(By.LinkText("Ver Usuários"));
        public IWebElement btnCriar => driver.FindElement(By.Name("doCreate"));
        public IWebElement txtLogin => driver.FindElement(By.Name("login"));
        public IWebElement txtNome => driver.FindElement(By.Name("firstName"));
        public IWebElement txtSobrenome => driver.FindElement(By.Name("lastName"));
        public IWebElement txtSenha => driver.FindElement(By.Id("password"));
        public IWebElement txtEmail => driver.FindElement(By.Id("email"));
        public IWebElement cbxPerfil => driver.FindElement(By.Name("rights_id"));
        public IWebElement cbxLocalizacao => driver.FindElement(By.Name("locale"));
        public IWebElement btnSalvar => driver.FindElement(By.Name("do_update"));
        public IWebElement checkBox => driver.FindElement(By.Name("user_is_active"));
        public IWebElement VerPerfil => driver.FindElement(By.LinkText("Ver Perfis"));
        public IWebElement BtnCriarPerfil => driver.FindElement(By.Name("doCreate"));
        public IWebElement TxtNomePerfil => driver.FindElement(By.Name("rolename"));
        public IWebElement CheckBoxCriar => driver.FindElement(By.Name("grant[mgt_testplan_create]"));
        public IWebElement BtnSalvarPerfil => driver.FindElement(By.Name("role_mgmt"));
        public IWebElement BtnSim => driver.FindElement(By.Id("ext-gen20"));

        #endregion

        public void CriarUsuarioDDT()
        {
            SeleniumUteis uteis = new SeleniumUteis();

            string searchText;
            string CSVFilePath = @"C:\Repositório de projetos\ProjetoMantisBase2\ProjetoMantisBase2\DDT Arquivos\Teste.csv";
            DataTable objDT;
            objDT = ProjetoTestLinkBase2.Uteis.CSVData.GetCSVData(CSVFilePath);
            uteis.ClicaBotao(abaUsuarios);
            foreach (DataRow objDR in objDT.Rows)
            {
                searchText = objDR["searchText"].ToString();
                string nome = searchText;
                uteis.ClicaBotao(btnCriar);
                uteis.preencheCampoInput(txtLogin, nome);
                uteis.preencheCampoInput(txtNome, nome);
                uteis.preencheCampoInput(txtSobrenome, nome);
                uteis.preencheCampoInput(txtSenha, nome);
                uteis.preencheCampoInput(txtEmail, SeleniumUteis.GerarEmail(nome));
                uteis.CBClick(cbxPerfil, "tester");
                uteis.CBClick(cbxLocalizacao, "Portuguese (Brazil)");
                uteis.ClicaBotao(btnSalvar);

            }
            

        }
        public void CriarUsuarioTesterAtivo()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();

            uteis.ClicaBotao(abaUsuarios);
            uteis.ClicaBotao(btnCriar);
            uteis.preencheCampoInput(txtLogin,nome);
            uteis.preencheCampoInput(txtNome,nome);
            uteis.preencheCampoInput(txtSobrenome,nome);
            uteis.preencheCampoInput(txtSenha,nome);
            uteis.preencheCampoInput(txtEmail,SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(cbxPerfil, "tester");
            uteis.CBClick(cbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(btnSalvar);

        }

        public string CriarUsuarioTesterAtivo( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();

            uteis.ClicaBotao(abaUsuarios);
            uteis.ClicaBotao(btnCriar);
            uteis.preencheCampoInput(txtLogin, nome);
            uteis.preencheCampoInput(txtNome, nome);
            uteis.preencheCampoInput(txtSobrenome, nome);
            uteis.preencheCampoInput(txtSenha, nome);
            uteis.preencheCampoInput(txtEmail, SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(cbxPerfil, "tester");
            uteis.CBClick(cbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(btnSalvar);
            return nome;

        }
        public void CriarUsuarioTesterInativo()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();

            uteis.ClicaBotao(abaUsuarios);
            uteis.ClicaBotao(btnCriar);
            uteis.preencheCampoInput(txtLogin, nome);
            uteis.preencheCampoInput(txtNome, nome);
            uteis.preencheCampoInput(txtSobrenome, nome);
            uteis.preencheCampoInput(txtSenha, nome);
            uteis.preencheCampoInput(txtEmail, SeleniumUteis.GerarEmail(nome));
            uteis.CBClick(cbxPerfil, "tester");
            uteis.CBClick(cbxLocalizacao, "Portuguese (Brazil)");
            uteis.ClicaBotao(checkBox);
            uteis.ClicaBotao(btnSalvar);

        }

        public void DesabilitarUsuarioTester()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome =CriarUsuarioTesterAtivo(nome);
            uteis.desabilitarUsuario(nome);
            uteis.clicaBotaoSim("Sim", "ext-comp-1035");
            Assert.AreEqual("Usuário "+nome+ " foi desabilitado com sucesso", driver.FindElement(By.CssSelector("p")).Text);

        }
        public void AtivarUsuarioDesabilitadoUsuarioTester()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarUsuarioTesterAtivo(nome);
            uteis.desabilitarUsuario(nome);
            uteis.clicaBotaoSim("Sim", "ext-comp-1035");
            Assert.AreEqual("Usuário " + nome + " foi desabilitado com sucesso", driver.FindElement(By.CssSelector("p")).Text);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            uteis.ClicaBotao(checkBox);
            uteis.ClicaBotao(btnSalvar);
            uteis.VerificarElementoTabela(nome);

        }
        public void CriarPerfil()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.preencheCampoInput(TxtNomePerfil,nome);
            uteis.ClicaBotao(CheckBoxCriar);
            uteis.ClicaBotao(BtnSalvarPerfil);
            uteis.verificaNomeTabela(nome);
        }
        public void CriarPerfil( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.preencheCampoInput(TxtNomePerfil, nome);
            uteis.ClicaBotao(CheckBoxCriar);
            uteis.ClicaBotao(BtnSalvarPerfil);
            uteis.verificaNomeTabela(nome);
        }
        public void DeletarPerfil()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPerfil(nome);
            ExcluiPerfil(nome);
            uteis.confirmaExclusaoTabela(nome);

        }
        public void CriarPerfilSemPermissao()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(VerPerfil);
            uteis.ClicaBotao(BtnCriarPerfil);
            uteis.preencheCampoInput(TxtNomePerfil, nome);
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

    }
}
