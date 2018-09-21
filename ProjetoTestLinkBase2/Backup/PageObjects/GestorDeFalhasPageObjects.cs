using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class GestorDeFalhasPageObjects : WebDriver
    {

        #region Mapeamento
        public IWebElement acessoGestorFalhas => driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Tipo'])[1]/preceding::th[1]"));
        public IWebElement criarGestorFalhas => driver.FindElement(By.Id("create"));
        public IWebElement nomeGestorFalhas => driver.FindElement(By.Id("name"));
        public IWebElement tipoGestorFalhas => driver.FindElement(By.Id("type"));
        public IWebElement exemplo => driver.FindElement(By.LinkText("Mostrar um exemplo de configuração"));
        public IWebElement configuracao => driver.FindElement(By.CssSelector("xmp"));
        public IWebElement configuracaoTxt => driver.FindElement(By.Name("cfg"));
        public IWebElement btnSalvar => driver.FindElement(By.Id("create"));
        public IWebElement BtnOrdenar => driver.FindElement(By.CssSelector("th"));
        public IWebElement BtnDeletarSim => driver.FindElement(By.Id("ext-gen20"));
        #endregion


       

        public void CriarGestorFalhas() {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(criarGestorFalhas);
            uteis.preencheCampoInput(nomeGestorFalhas, nome);
            uteis.selecionaRandomicoComboBox(tipoGestorFalhas);
            uteis.ClicaBotao(exemplo);
            uteis.preencheCampoInput(configuracaoTxt, configuracao.Text);
            uteis.ClicaBotao(btnSalvar);
            uteis.verificaNomeTabela(nome);
        }
        public void CriarGestorFalhas(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(criarGestorFalhas);
            uteis.preencheCampoInput(nomeGestorFalhas, nome);
            uteis.selecionaRandomicoComboBox(tipoGestorFalhas);
            uteis.ClicaBotao(exemplo);
            uteis.preencheCampoInput(configuracaoTxt, configuracao.Text);
            uteis.ClicaBotao(btnSalvar);
            uteis.verificaNomeTabela(nome);
        }
        public void VerificarConexao()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarGestorFalhas(nome);
          //  VerConexao(nome);
        }

     /*   public void VerConexao( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElement(By.TagName("td"));
                string texto = tds.Text.Trim();
                //  if (tds[i].Text.Equals(nome))
                if (nome.Equals(texto))
                {  
                   foreach (var anc in tds.FindElements  (By.TagName("a")))
                    {
                       

                    }
                  // var img =  tds[0].FindElement(By.TagName("img"));
                //   string mensagem =img.Text;
                   uteis.ClicaBotao(BtnDeletarSim);

                    return;
                }

            }//fim foreach


        }
        */
        public void EditarGestorFalhas()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            CriarGestorFalhas(nome);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            string novonome = SeleniumUteis.GerarNome();
            uteis.preencheCampoInput(nomeGestorFalhas, novonome);
            uteis.ClicaBotao(btnSalvar);
            Assert.AreEqual(novonome, driver.FindElement(By.LinkText(novonome)).Text.Trim());

        }

        public void DeletarGestorFalhas()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(criarGestorFalhas);
            uteis.preencheCampoInput(nomeGestorFalhas, nome);
            uteis.selecionaRandomicoComboBox(tipoGestorFalhas);
            uteis.ClicaBotao(exemplo);
            uteis.preencheCampoInput(configuracaoTxt, configuracao.Text);
            uteis.ClicaBotao(btnSalvar);
            uteis.verificaNomeTabela(nome);
            deletaTabelaGestorFalhas(nome);
            uteis.confirmaExclusaoTabela(nome);

        }

        public void deletaTabelaGestorFalhas(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                string texto = tds[0].Text.Trim();
                    //  if (tds[i].Text.Equals(nome))
                    if (nome.Equals(texto))
                    {
                        tds[3].FindElement(By.TagName("img")).Click();
                        uteis.ClicaBotao(BtnDeletarSim);
                        
                        return;
                    }
                
            }//fim foreach

        }


        /* public void OrdenaNomeCrescente(){
             SeleniumUteis uteis = new SeleniumUteis();

             uteis.ClicaBotao(BtnOrdenar);
             uteis.ClicaBotao(BtnOrdenar);
             uteis.VerificarOrdemCrescente();
            //confere os dados ordem crescente 
         }
         public void OrdenaNomeDecrescente()
         {
             SeleniumUteis uteis = new SeleniumUteis();
             uteis.ClicaBotao(BtnOrdenar);
             //confere os dados ordem decrescente 

         }*/

    }
}
