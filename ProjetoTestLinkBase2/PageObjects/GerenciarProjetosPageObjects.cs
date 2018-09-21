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
    class GerenciarProjetosPageObjects : WebDriver
    {
        #region Mapeamento
        public IWebElement btnCriar => driver.FindElement(By.Id("create"));
        public IWebElement cbxCriar => driver.FindElement(By.Name("copy_from_tproject_id"));
        public IWebElement txtnome => driver.FindElement(By.Name("tprojectName"));
        public IWebElement idAleatorio => driver.FindElement(By.Name("tcasePrefix"));
        public IWebElement txtDescricaoProjeto => driver.FindElement(By.Name("copy_from_tproject_id"));
        public IWebElement btnFinalizarCriacao => driver.FindElement(By.Name("doActionButton"));
        public IWebElement campoFiltro => driver.FindElement(By.Id("name"));
        public IWebElement btnFiltrar => driver.FindElement(By.Id("search"));
        public IWebElement btnResetFilter => driver.FindElement(By.Name("resetFilter"));
        public IWebElement btnSim => driver.FindElement(By.Id("ext-gen20"));
        public IWebElement CbxShow => driver.FindElement(By.Name("item_view_length"));


        #endregion


        public void CriarProjeto()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            uteis.ClicaBotao(btnCriar);
            new SelectElement(cbxCriar).SelectByText("Não");
            uteis.preencheCampoInput(txtnome, nome);
            uteis.preencheId(idAleatorio);
          //  uteis.preencheCampoInput(txtDescricaoProjeto, nome);
            uteis.ClicaBotao(btnFinalizarCriacao);
            new SelectElement(CbxShow).SelectByText("All");
            uteis.verificaNomeTabela(nome);
        }

        public String CriarProjeto( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(btnCriar);
            new SelectElement(cbxCriar).SelectByText("Não");
            uteis.preencheCampoInput(txtnome, nome);
            uteis.preencheId(idAleatorio);
            //  uteis.preencheCampoInput(txtDescricaoProjeto, nome);
            uteis.ClicaBotao(btnFinalizarCriacao);
            new SelectElement(CbxShow).SelectByText("All");

            uteis.verificaNomeTabela(nome);

            return nome;
        }

        public void filtrarProjeto()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.preencheCampoInput(campoFiltro, nome);
            uteis.ClicaBotao(btnFiltrar);
            new SelectElement(CbxShow).SelectByText("All");
            uteis.verificaNomesFiltro(nome);
        }

        public void ResetarfiltroProjeto()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            int count;
            nome = CriarProjeto(nome);
            count = uteis.verificarQuantidadesLinhas();
            uteis.preencheCampoInput(campoFiltro, nome);
            uteis.ClicaBotao(btnFiltrar);
            new SelectElement(CbxShow).SelectByText("All");
            uteis.verificaNomesFiltro(nome);
            uteis.ClicaBotao (btnResetFilter);
            new SelectElement(CbxShow).SelectByText("All");
            Assert.AreEqual(count, uteis.verificarQuantidadesLinhas());
        }
        public void DeletarProjetoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.clicaPosicaoTabela(nome,7);
            uteis.ClicaBotao(btnSim);
            new SelectElement(CbxShow).SelectByText("All");
            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));
        }

        

        public void DesativarProjetoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.clicaPosicaoTabela(nome,5);
//            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));
        }

        public String DesativarProjetoTeste(string retorno)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.clicaPosicaoTabela(nome, 5);
            //            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));
            return retorno = nome;
        }

        public void AtivarProjetoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            String nome = null;
            nome = DesativarProjetoTeste(nome);
            
            uteis.clicaPosicaoTabela(nome, 5);
                     
        }
        public void DesativarRequisitosProjetoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.clicaPosicaoTabela(nome, 4);
            new SelectElement(CbxShow).SelectByText("All");
            uteis.clicaPosicaoTabela(nome, 4);
            //Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));
            
        }

        public void AtivarRequisitosProjetoTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = CriarProjeto(nome);
            uteis.clicaPosicaoTabela(nome, 4);
                      
        }

    }
}
