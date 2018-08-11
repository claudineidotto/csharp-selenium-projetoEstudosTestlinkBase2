using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMantisBase2.PageObjects
{
    class CamposPersonalizadosPageObjects : WebDriver
    {

        SeleniumUteis uteis = new SeleniumUteis();

        #region Mapeamento
        public IWebElement acessoCamposP => driver.FindElement(By.CssSelector("h1.title"));
        #endregion

        public void verificaAcessoCamposPersonalizados()
        {
            uteis.EsperaElemento(acessoCamposP);
            Assert.AreEqual("Campos Personalizados", acessoCamposP.ToString());
        }

    }
}
