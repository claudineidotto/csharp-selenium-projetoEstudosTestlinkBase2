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
    class BaselinesPageObjects :WebDriver
    {

        #region Mapeamento
        public IWebElement BtnCriar => driver.FindElement(By.Name("create_build"));
        public IWebElement BtnAtualizar => driver.FindElement(By.Name("do_update"));
        public IWebElement TxtTitulo => driver.FindElement(By.Id("build_name"));
        public IWebElement BtnCriarFinalizar => driver.FindElement(By.Name("do_create"));
        public IWebElement BtnExcluirSim => driver.FindElement(By.Id("ext-gen20"));



        #endregion
       

        public void CriarBaseline()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string titulo = SeleniumUteis.GerarNome();
            uteis.EsperaElemento(BtnCriar);
            uteis.ClicaBotao(BtnCriar);
            uteis.PreencheCampoInput(TxtTitulo, titulo);
            uteis.EsperaElemento(BtnCriarFinalizar);
            uteis.ClicaBotao(BtnCriarFinalizar);
            uteis.VerificaNomeTabela(titulo);
        }
        public void CriarBaseline(string titulo)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.EsperaElemento(BtnCriar);
            uteis.ClicaBotao(BtnCriar);
            uteis.PreencheCampoInput(TxtTitulo, titulo);
            uteis.EsperaElemento(BtnCriarFinalizar);
            uteis.ClicaBotao(BtnCriarFinalizar);
            uteis.VerificaNomeTabela(titulo);
        }
        public void DeletarBaseline()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string titulo = SeleniumUteis.GerarNome();
            CriarBaseline(titulo);
            uteis.ClicaPosicaoTabela(titulo, 5);
            uteis.ClicaBotao(BtnExcluirSim);
            Assert.AreEqual(null, uteis.ConfirmaExclusaoTabela(titulo));

        }

        public void EditarBaseline()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string titulo = SeleniumUteis.GerarNome();
            CriarBaseline(titulo);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(titulo)));
            string novonome = SeleniumUteis.GerarNome();
            uteis.PreencheCampoInput(TxtTitulo, novonome);
            uteis.ClicaBotao(BtnAtualizar);
            Assert.AreEqual(novonome, driver.FindElement(By.LinkText(novonome)).Text.Trim());

        }


    }
}

