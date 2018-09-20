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
    class SelecionarCamposPersonalizadosPageObjects : WebDriver
    {
        public void SelecionarCamposPersonalizadosPageObjets() {
        }

        #region Mapeamento
        public IWebElement btnAtribuir => driver.FindElement(By.Id("this.name"));
        public IWebElement btnNaoAtribuir => driver.FindElement(By.Name("doUnassign"));


        #endregion

        public void  AtribuirCamposPersonalizados(string nome){
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.selecionaCheckBox(nome,"free_cf");
            uteis.ClicaBotao(btnAtribuir);
            uteis.VerificarElementoTabela(nome, "assigned_cf");
        }
        public void RemoverAtribuicaoCamposPersonalizados(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            AtribuirCamposPersonalizados(nome);
            uteis.selecionaCheckBox(nome, "assigned_cf");
            uteis.ClicaBotao(btnNaoAtribuir);
            uteis.VerificarElementoTabela(nome, "free_cf");

        }

    }
    
}
