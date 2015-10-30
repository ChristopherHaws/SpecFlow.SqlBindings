using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlow.SqlServer.Tests
{
	[Binding]
	public sealed class StepDefinition1
	{
		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		[Given("I have entered (.*) into the calculator")]
		public void GivenIHaveEnteredSomethingIntoTheCalculator(Int32 number)
		{
			List<Int32> numbers;
			if (!ScenarioContext.Current.TryGetValue("Numbers", out numbers))
			{
				numbers = new List<Int32>();
				ScenarioContext.Current.Add("Numbers", numbers);
			}

			numbers.Add(number);
		}

		[When("I press add")]
		public void WhenIPressAdd()
		{
			var numbers = ScenarioContext.Current.Get<List<Int32>>("Numbers");

			var result = numbers.Sum();
			
			ScenarioContext.Current.Add("Result", result);
		}

		[Then("the result should be (.*) on the screen")]
		public void ThenTheResultShouldBe(Int32 expected)
		{
			var actual = ScenarioContext.Current.Get<Int32>("Result");

			Assert.AreEqual(expected, actual);
		}
	}
}
