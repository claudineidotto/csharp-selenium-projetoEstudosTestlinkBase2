using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Uteis
{
    class SeleniumUteis
    {

        public void preencheCampoInput(IWebElement elemento,String valor ){
            //espera elemento
            //limpa o elemento 
            //preenche o elemento 
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            elemento.Clear();
            elemento.SendKeys(valor);
          }
        public void ClicaBotao(IWebElement elemento)
        {
            //espera elemento
            //limpa o elemento 
            //preenche o elemento 
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            elemento.Click();
        }






    }
}
