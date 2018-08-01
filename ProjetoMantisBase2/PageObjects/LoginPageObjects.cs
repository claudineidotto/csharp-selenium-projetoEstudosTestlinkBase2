using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    public class LoginPageObjects : WebDriver
    {
        public LoginPageObjects() {
            PageFactory.InitElements(driver, this);
        }


        #region Mapeamento
        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtPassword{ get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//font")]
        public IWebElement msgLoginErro { get; set; }

        #endregion

        SeleniumUteis uteis = new SeleniumUteis();

        public void preencheLogin(String username) {
            uteis.preencheCampoInput(txtUsername, username);
            
        }

        public void preencheSenha(String password) {
            uteis.preencheCampoInput(txtPassword, password);
        }

        public void clicaLogin (){
            uteis.ClicaBotao(btnLogin);
        }

        public void verificaLoginFalha() {
            string frasefalha = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            msgLoginErro.Text.ToString();

        }

        public void verificaLoginSucesso()
        {
            
            msgLoginErro.Text.ToString();

        }
    }
}
