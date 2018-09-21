using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class GerenciarPlanoTestePageObjects : WebDriver
    {
        #region Mapeamento
        public IWebElement BtnCriar => driver.FindElement(By.Name("create_testplan"));
        public IWebElement TxtNome => driver.FindElement(By.Name("testplan_name"));
        public IWebElement BtnCriarFinal => driver.FindElement(By.Name("do_create"));
        public IWebElement CbxAtivo => driver.FindElement(By.Name("active"));
        public IWebElement BtnDeletarSim => driver.FindElement(By.Id("ext-gen20"));
        public IWebElement BtnAtualizar => driver.FindElement(By.Name("do_update"));
        #endregion


        public void CriarPlanoTesteInativo (){
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(BtnCriar);
            uteis.preencheCampoInput(TxtNome, nome);
            uteis.ClicaBotao(BtnCriarFinal);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }

        public void CriarPlanoTesteAtivo()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(BtnCriar);
            uteis.preencheCampoInput(TxtNome, nome);
            uteis.ClicaBotao(CbxAtivo);
            uteis.ClicaBotao(BtnCriarFinal);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }

        public void CriarPlanoTesteInativo(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnCriar);
            uteis.preencheCampoInput(TxtNome, nome);
            Thread.Sleep(100);
            uteis.ClicaBotao(BtnCriarFinal);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }
        public void CriarPlanoTesteAtivo(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnCriar);
            uteis.preencheCampoInput(TxtNome, nome);
            uteis.ClicaBotao(CbxAtivo);
            Thread.Sleep(100);
            uteis.ClicaBotao(BtnCriarFinal);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }

        public void EditarPlanoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPlanoTesteInativo(nome);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            string novonome = SeleniumUteis.GerarNome();
            uteis.preencheCampoInput(TxtNome, novonome);
            uteis.ClicaBotao(BtnAtualizar);
            Assert.AreEqual(novonome, driver.FindElement(By.LinkText(novonome)).Text.Trim());
        }
        public void AtivarPlanoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPlanoTesteInativo(nome);
            uteis.clicaPosicaoTabela(nome, 5);
            Assert.AreEqual("Active (click to set inactive)", VerificarStatus(nome));
        }
        public void DesativarPlanoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPlanoTesteAtivo(nome);
            uteis.clicaPosicaoTabela(nome, 5);
            Assert.AreEqual("Inactive (click to set active)",VerificarStatus(nome));       
        }

        public string VerificarStatus(string nome) {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                string texto = tds[0].Text.Trim();
                if (nome.Equals(texto))
                {
                    var status = tds[5].FindElement(By.TagName("input"));
                    return status.GetAttribute("title");
                }

            }//fim foreach

            return null;
        }

        public void DeletarPlanoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarPlanoTesteAtivo(nome);
            ExcluirPlanoTeste(nome);
            uteis.ClicaBotao(BtnDeletarSim);
            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));
        }

        public void ExcluirPlanoTeste(string nome) {

            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                string texto = tds[0].Text.Trim();
                if (nome.Equals(texto))
                {
                    tds[7].FindElement(By.TagName("img")).Click();

                    return;
                }

            }//fim foreach
        }

    }


}

