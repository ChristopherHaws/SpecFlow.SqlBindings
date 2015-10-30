using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.SqlBindings
{
	[Binding]
	public class QuerySteps
    {
		[Given("I have the following data in the '(.*)' table")]
		public void GivenIHaveTheFollowingDataInTheTable(String tableName, Table table)
		{
			var statement = new StringBuilder();
			statement.AppendLine("INSERT INTO " + tableName);
			statement.Append("(");

			var columnIndex = 0;
			foreach (var columnName in table.Header)
			{
				if (++columnIndex > 1)
				{
					statement.Append(", ");
				}

				statement.AppendFormat("[{0}]", columnName);
			}

			statement.AppendLine(") VALUES");

			var rowIndex = 0;
			foreach (var row in table.Rows)
			{
				statement.Append("(");

				columnIndex = 0;

				foreach (var value in row.Values)
				{
					if (++columnIndex > 1)
					{
						statement.Append(", ");
					}

					statement.Append(value);
				}

				statement.Append(")");

				if (++rowIndex < table.RowCount)
				{
					statement.Append(",");
				}

				statement.AppendLine();
			}

			List<String> preTestQueries;
			if (!ScenarioContext.Current.TryGetValue("PreTestQueries", out preTestQueries))
			{
				preTestQueries = new List<String>();
				ScenarioContext.Current.Add("PreTestQueries", preTestQueries);
			}

			preTestQueries.Add(statement.ToString());
		}

		[When("I execute '(.*)'")]
		public void WhenIExecute(String storedProcedureName)
		{
			List<String> testQueries;
			if (!ScenarioContext.Current.TryGetValue("TestQueries", out testQueries))
			{
				testQueries = new List<String>();
				ScenarioContext.Current.Add("TestQueries", testQueries);
			}

			testQueries.Add("EXEC " + storedProcedureName);
		}

		[When("I execute '(.*)' with the following parameters")]
		public void WhenIExecute(String storedProcedureName, Table parameters)
		{
			ScenarioContext.Current.Pending();
		}

		[Then("I want ResultSet (.*) to be")]
		public void ThenIWantTheResultSetToBe(Int32 resultSet, Table expectedValues)
		{
			ScenarioContext.Current.Pending();
		}
	}
}
