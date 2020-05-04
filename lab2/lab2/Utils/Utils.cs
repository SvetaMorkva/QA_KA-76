using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Utils
{
    class UtilsSelenium
    {
        public UtilsSelenium()
        {
        }

        public List<string> GetAllElemsList(IList<IWebElement> elemsList)
        {
            IWebElement[] tasksElems = elemsList.ToArray();

            var strsList = new List<string>();

            foreach (IWebElement taskElem in tasksElems)
            {
                strsList.Add(taskElem.GetAttribute("textContent"));
            }
            return strsList;
        }
    }
}
