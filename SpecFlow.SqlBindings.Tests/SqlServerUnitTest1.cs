using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlow.SqlBindings.Tests
{
	[TestClass()]
	public class SqlServerUnitTest1 : SqlDatabaseTestClass
	{

		public SqlServerUnitTest1()
		{
			InitializeComponent();
		}

		[TestInitialize()]
		public void TestInitialize()
		{
			base.InitializeTest();
		}
		[TestCleanup()]
		public void TestCleanup()
		{
			base.CleanupTest();
		}

		[TestMethod()]
		public void SqlTest1()
		{
			SqlDatabaseTestActions testActions = this.SqlTest1Data;
			// Execute the pre-test script
			// 
			System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
			SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
			// Execute the test script
			// 
			System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
			SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
			// Execute the post-test script
			// 
			System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
			SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
		}

		#region Designer support code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SqlTest1_TestAction;
			Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SqlTest1_PretestAction;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerUnitTest1));
			Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition bookTitleIsHarryPotter;
			this.SqlTest1Data = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
			SqlTest1_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
			SqlTest1_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
			bookTitleIsHarryPotter = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
			// 
			// SqlTest1Data
			// 
			this.SqlTest1Data.PosttestAction = null;
			this.SqlTest1Data.PretestAction = SqlTest1_PretestAction;
			this.SqlTest1Data.TestAction = SqlTest1_TestAction;
			// 
			// SqlTest1_TestAction
			// 
			SqlTest1_TestAction.Conditions.Add(bookTitleIsHarryPotter);
			resources.ApplyResources(SqlTest1_TestAction, "SqlTest1_TestAction");
			// 
			// SqlTest1_PretestAction
			// 
			resources.ApplyResources(SqlTest1_PretestAction, "SqlTest1_PretestAction");
			// 
			// bookTitleIsHarryPotter
			// 
			bookTitleIsHarryPotter.ColumnNumber = 1;
			bookTitleIsHarryPotter.Enabled = true;
			bookTitleIsHarryPotter.ExpectedValue = "Harry Potter and the Sorcerers Stone";
			bookTitleIsHarryPotter.Name = "bookTitleIsHarryPotter";
			bookTitleIsHarryPotter.NullExpected = false;
			bookTitleIsHarryPotter.ResultSet = 1;
			bookTitleIsHarryPotter.RowNumber = 1;
		}

		#endregion


		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		#endregion

		private SqlDatabaseTestActions SqlTest1Data;
	}
}
