using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace CaseFlow_Database_Tests
{
    [TestClass()]
    public class GetUserTests : SqlDatabaseTestClass
    {

        public GetUserTests()
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
        public void GetUser_ReturnsUser_Test()
        {
            SqlDatabaseTestActions testActions = this.GetUser_ReturnsUser_TestData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetUser_ReturnsUser_Test_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetUser_ReturnsUser_Test_PosttestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetUserTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckUsersReturned;
            this.GetUser_ReturnsUser_TestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            GetUser_ReturnsUser_Test_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            GetUser_ReturnsUser_Test_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckUsersReturned = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            // 
            // GetUser_ReturnsUser_TestData
            // 
            this.GetUser_ReturnsUser_TestData.PosttestAction = GetUser_ReturnsUser_Test_PosttestAction;
            this.GetUser_ReturnsUser_TestData.PretestAction = null;
            this.GetUser_ReturnsUser_TestData.TestAction = GetUser_ReturnsUser_Test_TestAction;
            // 
            // GetUser_ReturnsUser_Test_TestAction
            // 
            GetUser_ReturnsUser_Test_TestAction.Conditions.Add(CheckUsersReturned);
            resources.ApplyResources(GetUser_ReturnsUser_Test_TestAction, "GetUser_ReturnsUser_Test_TestAction");
            // 
            // GetUser_ReturnsUser_Test_PosttestAction
            // 
            resources.ApplyResources(GetUser_ReturnsUser_Test_PosttestAction, "GetUser_ReturnsUser_Test_PosttestAction");
            // 
            // CheckUsersReturned
            // 
            CheckUsersReturned.Enabled = true;
            CheckUsersReturned.Name = "CheckUsersReturned";
            resources.ApplyResources(CheckUsersReturned, "CheckUsersReturned");
            CheckUsersReturned.Verbose = false;
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

        private SqlDatabaseTestActions GetUser_ReturnsUser_TestData;
    }
}
