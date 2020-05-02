using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using IlMolinoSite.PageObject;

namespace ilMolinoTest
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private string _url = "https://ilmolino.ua/delivery.html";

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
        
        [TestCase("Verona", "m-name-1165015-1-0")]
        [TestCase("Barbeque Gourmet", "m-name-1165008-1-0")]
        [TestCase("Margherita", "m-name-557-1-0")]
        public void TestBuyPizzaInSiteIlMolino(string pizza, string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var pizzaPage = new PizzaPage(_driver);

            mainPage.ClickOnPizza();
            Thread.Sleep(2000);
            if (pizza == "Verona")
                pizzaPage.BuyPizzaVerona();
            else if (pizza == "Barbeque Gourmet")
                pizzaPage.BuyPizzaBarbuqueGourmet();
            else
                pizzaPage.BuyPizzaMargherita();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";
            if(expected == count)
            {
                bool spanElement = mainPage.SpanElementInTheBox(spanElementInBox);
                flags = spanElement;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase ("m-name-1165015-1-0", "m-name-1165002-1-0")]
        public void TestBuyPizzaAndSaladInSiteIlMolino(string spanElementPizza, string spanElementSalad)
        {
            bool flags = false;

            var mainPage = new MainPage(_driver);
            var pizzaPage = new PizzaPage(_driver);
            var saladsPage = new SaladsPage(_driver);

            mainPage.ClickOnPizza();
            Thread.Sleep(2000);
            pizzaPage.BuyPizzaVerona();
            Thread.Sleep(2000);
            mainPage.ClickOnSalad();
            Thread.Sleep(2000);
            saladsPage.BuyVealSalad();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(2)";
            if (expected == count)
            {
                bool spanPizza = mainPage.SpanElementInTheBox(spanElementPizza);
                bool spanSalads = mainPage.SpanElementInTheBox(spanElementSalad);
                flags = spanPizza && spanSalads;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase ("m-name-577-1-0")]
        public void TestBuyHitPizzaInSiteIlMolino(string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var hitPizza = new HitPizzaPage(_driver);

            mainPage.ClickOnHitPizza();
            Thread.Sleep(2000);
            hitPizza.BuyPizzaAmericana();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";
            if (expected == count)
            {
                bool spanElement = mainPage.SpanElementInTheBox(spanElementInBox);
                flags = spanElement;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase ("m-name-1165015-1-0")]
        public void TestBuyTwoPizzaOneTypeInSiteIlMolino(string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var pizzaPage = new PizzaPage(_driver);

            mainPage.ClickOnPizza();
            Thread.Sleep(2000);
            pizzaPage.BuyPizzaVerona();
            Thread.Sleep(2000);
            mainPage.ClickOnBox();
            Thread.Sleep(2000);
            mainPage.ClickOnBox();
            Thread.Sleep(3000);
            mainPage.ClickPluxInBox();
            Thread.Sleep(2000);
            string count = mainPage.CountProducts;
            string expected = "(2)";
            if (expected == count)
            {
                bool spanPizzaOne = mainPage.SpanElementInTheBox(spanElementInBox);
                mainPage.RemoveElementWithListSpanElementInBox(spanElementInBox);
                bool spanPizzaTwo = mainPage.SpanElementInTheBox(spanElementInBox);
                flags = spanPizzaOne && spanPizzaTwo;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase ("+ Філе курки - 47 грн")]
        public void TestBuyPizzaWithIngredientsInSiteIlMolino(string ingredient)
        {
            bool flags = false;
            string url = "https://ilmolino.ua/delivery/pizza/milano.html";
            _driver.Navigate().GoToUrl(url);
            var milanoPage = new MilanoPage(_driver);

            Thread.Sleep(2000);
            milanoPage.ClickOnButtonAddIngredients();
            Thread.Sleep(2000);
            milanoPage.ClickOnPlusButtonChickenFillet();
            Thread.Sleep(3000);
            string expectedPrice = "264";
            string price = milanoPage.Price;
            flags = expectedPrice == price && milanoPage.CheckListIngredients(ingredient);
            Assert.AreEqual(expectedPrice, price, "There is no item in the box");
        }
        
        [TestCase("Chicken Soup With Past", "m-name-704-1-0")]
        [TestCase("Tomato Soup", "m-name-1164320-1-0")]
        public void TestBuySoupInSiteIlMolino(string soup, string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var soupPage = new SoupPage(_driver);

            mainPage.ClickOnSoup();
            Thread.Sleep(2000);
            if (soup == "Chicken Soup With Past")
                soupPage.BuyChickenSoupWithPasta();
            else
                soupPage.BuyTomatoSoup();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";
            if (expected == count)
                flags = mainPage.SpanElementInTheBox(spanElementInBox);
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase("SyrnikiWithRaisins", "m-name-1165205-1-0")]
        [TestCase("Vanilla Classic Ice Cream", "m-name-1165308-1-0")]
        [TestCase("Dark Chocolate Ice Cream", "m-name-1165165-1-0")]
        public void TestBuyDessertInSiteIlMolino(string dessert, string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var dessertPage = new DessertPage(_driver);

            mainPage.ClickOnDessert();
            Thread.Sleep(2000);
            if (dessert == "SyrnikiWithRaisins")
                dessertPage.BuySyrnikiWithRaisins();
            else if (dessert == "Vanilla Classic Ice Cream")
                dessertPage.BuyVanillaClassicIceCream();
            else
                dessertPage.BuyDarkChocolateIceCream();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";
            if (count == expected)
                flags = mainPage.SpanElementInTheBox(spanElementInBox);
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        [TestCase("Pappardelle With Veal Cheeks", "m-name-1165004-1-0")]
        [TestCase("Ravioli With Mushroom And Tofu", "m-name-1165005-1-0")]
        [TestCase("Dorado With Vegetables", "m-name-1165006-1-0")]
        public void TestBuyMainDishesInSiteIlMolino(string mainDishes, string spanElementInBox)
        {
            bool flags = false;

            var mainPage = new MainPage(_driver);
            var mainDishesPage = new MainDishesPage(_driver);

            mainPage.ClickOnMainDishes();
            Thread.Sleep(2000);
            if (mainDishes == "Pappardelle With Veal Cheeks")
                mainDishesPage.BuyPappardelleWithVealCheeks();
            else if (mainDishes == "Ravioli With Mushroom And Tofu")
                mainDishesPage.BuyRavioliWithMushroomAndTofu();
            else
                mainDishesPage.BuyDoradoWithVegetables();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";

            if (expected == count)
            {
                bool spanElement = mainPage.SpanElementInTheBox(spanElementInBox);
                flags = spanElement;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }
        
        
        [TestCase("Lime Lemonade", "m-name-733-1-0")]
        [TestCase("Burn", "m-name-1163499-1-0")]
        [TestCase("BuyGinger Natural Tea Concentrate", "m-name-1165168-1-0")]
        public void TestBuyBeveragesInSiteIlMolino(string beverages, string spanElementInBox)
        {
            bool flags = false;
            var mainPage = new MainPage(_driver);
            var beveragesPage = new BeveragesPage(_driver);
            mainPage.ClickOnBeverages();
            Thread.Sleep(2000);
            if (beverages == "Lime Lemonade")
                beveragesPage.BuyLimeLemonade();
            else if (beverages == "Burn")
                beveragesPage.BuyBurn();
            else
                beveragesPage.BuyGingerNaturalTeaConcentrate();
            Thread.Sleep(3000);
            string count = mainPage.CountProducts;
            string expected = "(1)";
            if (expected == count)
            {
                bool spanElement = mainPage.SpanElementInTheBox(spanElementInBox);
                flags = spanElement;
            }
            Assert.IsTrue(flags, "There is no item in the box");
        }

        [TestCase("EN", "EN")]
        [TestCase("RU", "RU")]
        [TestCase("UA", "UA")]
        public void TestLocalizationInSiteIlMolino(string expected, string langage)
        {
            var mainPage = new MainPage(_driver);

            mainPage.ClickOnLangage();
            Thread.Sleep(2000);
            if (langage == "EN")
                mainPage.SelectEnglish();
            else if (langage == "RU")
                mainPage.SelectRussia();
            else
                mainPage.SelectUkrainian();
            Thread.Sleep(2000);
            mainPage.ClickOnMoney();
            Thread.Sleep(3000);
            var result = mainPage.Langage;
            Assert.AreEqual(expected, result, "Localization does not match");
        }
        
    }
}