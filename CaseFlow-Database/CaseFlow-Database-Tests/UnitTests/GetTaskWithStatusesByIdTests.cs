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
    public class GetTaskWithStatusesByIdTests : SqlDatabaseTestClass
    {

        public GetTaskWithStatusesByIdTests()
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
        public void GetTaskWithStatusesById_Returns_Tasks()
        {
            SqlDatabaseTestActions testActions = this.GetTaskWithStatusesById_Returns_TasksData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetTaskWithStatusesById_Returns_Tasks_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckTaskAndStatusesReturned;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetTaskWithStatusesByIdTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetTaskWithStatusesById_Returns_Tasks_PosttestAction;
            this.GetTaskWithStatusesById_Returns_TasksData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            GetTaskWithStatusesById_Returns_Tasks_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckTaskAndStatusesReturned = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            GetTaskWithStatusesById_Returns_Tasks_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // GetTaskWithStatusesById_Returns_Tasks_TestAction
            // 
            GetTaskWithStatusesById_Returns_Tasks_TestAction.Conditions.Add(CheckTaskAndStatusesReturned);
            resources.ApplyResources(GetTaskWithStatusesById_Returns_Tasks_TestAction, "GetTaskWithStatusesById_Returns_Tasks_TestAction");
            // 
            // CheckTaskAndStatusesReturned
            // 
            CheckTaskAndStatusesReturned.Enabled = true;
            CheckTaskAndStatusesReturned.Name = "CheckTaskAndStatusesReturned";
            resources.ApplyResources(CheckTaskAndStatusesReturned, "CheckTaskAndStatusesReturned");
            CheckTaskAndStatusesReturned.Verbose = false;
            // 
            // GetTaskWithStatusesById_Returns_TasksData
            // 
            this.GetTaskWithStatusesById_Returns_TasksData.PosttestAction = GetTaskWithStatusesById_Returns_Tasks_PosttestAction;
            this.GetTaskWithStatusesById_Returns_TasksData.PretestAction = null;
            this.GetTaskWithStatusesById_Returns_TasksData.TestAction = GetTaskWithStatusesById_Returns_Tasks_TestAction;
            // 
            // GetTaskWithStatusesById_Returns_Tasks_PosttestAction
            // 
            resources.ApplyResources(GetTaskWithStatusesById_Returns_Tasks_PosttestAction, "GetTaskWithStatusesById_Returns_Tasks_PosttestAction");
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

        private SqlDatabaseTestActions GetTaskWithStatusesById_Returns_TasksData;
    }
}
