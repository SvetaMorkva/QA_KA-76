using System;
using TechTalk.SpecFlow;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class jopasteps
    {
        [When(@"jopa comes")]
        public void WhenJopaComes()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"be brave")]
        public void ThenBeBrave()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
