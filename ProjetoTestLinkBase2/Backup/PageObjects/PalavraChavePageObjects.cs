using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class PalavraChavePageObjects: WebDriver
    {

        #region
        public IWebElement BtnPalavraChave => driver.FindElement(By.Id("create_keyword"));
        public IWebElement TxtPalavraChave => driver.FindElement(By.Name("keyword"));
        public IWebElement TxtDescricao => driver.FindElement(By.Name("notes"));
        public IWebElement BtnSalvar => driver.FindElement(By.Name("create_req"));

        #endregion

        public void CriarPalavraChave()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnPalavraChave);
            string palavrachave = SeleniumUteis.GerarPalavraChave();
            uteis.preencheCampoInput(TxtPalavraChave, palavrachave);
            uteis.preencheCampoInput(TxtDescricao, palavrachave);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(palavrachave, driver.FindElement(By.LinkText(palavrachave)).Text);
        }

        public void CriarPalavraChave(string palavrachave)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnPalavraChave);
            
            uteis.preencheCampoInput(TxtPalavraChave, palavrachave);
            uteis.preencheCampoInput(TxtDescricao, palavrachave);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(palavrachave, driver.FindElement(By.LinkText(palavrachave)).Text);
        }
        public void DeletarPalavraChave()
        {
            string palavrachave = SeleniumUteis.GerarPalavraChave();
            SeleniumUteis uteis = new SeleniumUteis();
            CriarPalavraChave(palavrachave);
            uteis.clicaPosicaoTabela(palavrachave, 2);
            uteis.clicaBotaoSim("Sim", "ext-comp-1005");
            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(palavrachave));

        }


    }
}
