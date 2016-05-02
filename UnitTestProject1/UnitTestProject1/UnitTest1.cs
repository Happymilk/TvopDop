using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        RemoteWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");
            
            var name_l = driver.FindElementByName("name_l").Text;
            var name_f = driver.FindElementByName("name_f").Text;
            var name_m = driver.FindElementByName("name_m").Text;

            Assert.AreEqual("", name_l);
            Assert.AreEqual("", name_f);
            Assert.AreEqual("", name_m);
        }

        [TestMethod]
        public void TestMethod2()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var bd_d = driver.FindElementByName("bd_d").Text;
            var bd_m = driver.FindElementByName("bd_m").Text;
            var bd_y = driver.FindElementByName("bd_y").Text;

            Assert.AreEqual("01", bd_d);
            Assert.AreEqual("01", bd_m);
            Assert.AreEqual("1970", bd_y);
        }

        [TestMethod]
        public void TestMethod3()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var gender1 = driver.FindElementByName("gender").Selected;
            var gender2 = driver.FindElementByXPath("//input[@name='gender']").Selected;

            Assert.AreEqual(false, gender1);
            Assert.AreEqual(false, gender2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var cnt = driver.FindElementByName("cnt");
            var select = new SelectElement(cnt);

            select.SelectByValue("---");
            Assert.AreEqual(false, driver.FindElementByName("reg").Enabled);
            Assert.AreEqual(false, driver.FindElementByName("city").Enabled);
        }

        [TestMethod]
        public void TestMethod5()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var cnt = driver.FindElementByName("cnt");
            var select = new SelectElement(cnt);

            Assert.AreEqual(false, driver.FindElementByName("reg").Enabled);

            select.SelectByValue("bel");

            Assert.AreEqual(true, driver.FindElementByName("reg").Enabled);
        }

        [TestMethod]
        public void TestMethod6()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var go = driver.FindElementByName("go");
            go.Click();
            Thread.Sleep(3000);

            var msg = driver.FindElementById("msg").Displayed;
            Assert.AreEqual(true, msg);

            var b = driver.FindElementByCssSelector("b").Text;
            Assert.AreEqual(b, "Не указана фамилия Не указано имя Не указано отчество Неверный пароль");
        }

        [TestMethod]
        public void TestMethod7()
        {
            driver.Navigate().GoToUrl("http://svyatoslav.biz/testlab/megaform.php");

            var bio = driver.FindElementByName("bio");
            var family = driver.FindElementByName("family");

            Assert.AreEqual("textarea", bio.TagName);
            Assert.AreEqual("textarea", family.TagName);
        }
    }
}
