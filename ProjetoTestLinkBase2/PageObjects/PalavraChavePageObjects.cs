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
        public IWebElement BtnDeletarSim => driver.FindElement(By.Name(" ext-gen20"));    
        #endregion

        public void CriarPalavraChave()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnPalavraChave);
            string palavrachave = SeleniumUteis.GerarPalavraChave();
            uteis.PreencheCampoInput(TxtPalavraChave, palavrachave);
            uteis.PreencheCampoInput(TxtDescricao, palavrachave);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(palavrachave, driver.FindElement(By.LinkText(palavrachave)).Text);
        }

        public void CriarPalavraChave(string palavrachave)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnPalavraChave);
            uteis.PreencheCampoInput(TxtPalavraChave, palavrachave);
            uteis.PreencheCampoInput(TxtDescricao, palavrachave);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(palavrachave, driver.FindElement(By.LinkText(palavrachave)).Text);
        }
        public void DeletarPalavraChave()
        {
            string palavrachave = SeleniumUteis.GerarPalavraChave();
            SeleniumUteis uteis = new SeleniumUteis();
            CriarPalavraChave(palavrachave);
            uteis.ClicaPosicaoTabela(palavrachave, 2);
            uteis.ClicaBotao(BtnDeletarSim);
            Assert.AreEqual(null, uteis.ConfirmaExclusaoTabela(palavrachave));
        }


    }
}
