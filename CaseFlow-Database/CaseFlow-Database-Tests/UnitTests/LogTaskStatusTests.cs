using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseFlow_Database_Tests.UnitTests
{
    [TestClass()]
    public class caseFlow : SqlDatabaseTestClass
    {

        public caseFlow()
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
        public void LogTaskStatus_SucceedsWithValidData()
        {
            SqlDatabaseTestActions testActions = this.LogTaskStatus_SucceedsWithValidDataData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LogTaskStatus_SucceedsWithValidData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckTaskStatusUpdate;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(caseFlow));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LogTaskStatus_SucceedsWithValidData_PosttestAction;
            this.LogTaskStatus_SucceedsWithValidDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            LogTaskStatus_SucceedsWithValidData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckTaskStatusUpdate = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            LogTaskStatus_SucceedsWithValidData_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // LogTaskStatus_SucceedsWithValidData_TestAction
            // 
            LogTaskStatus_SucceedsWithValidData_TestAction.Conditions.Add(CheckTaskStatusUpdate);
            resources.ApplyResources(LogTaskStatus_SucceedsWithValidData_TestAction, "LogTaskStatus_SucceedsWithValidData_TestAction");
            // 
            // LogTaskStatus_SucceedsWithValidDataData
            // 
            this.LogTaskStatus_SucceedsWithValidDataData.PosttestAction = LogTaskStatus_SucceedsWithValidData_PosttestAction;
            this.LogTaskStatus_SucceedsWithValidDataData.PretestAction = null;
            this.LogTaskStatus_SucceedsWithValidDataData.TestAction = LogTaskStatus_SucceedsWithValidData_TestAction;
            // 
            // CheckTaskStatusUpdate
            // 
            CheckTaskStatusUpdate.Enabled = true;
            CheckTaskStatusUpdate.Name = "CheckTaskStatusUpdate";
            resources.ApplyResources(CheckTaskStatusUpdate, "CheckTaskStatusUpdate");
            CheckTaskStatusUpdate.Verbose = false;
            // 
            // LogTaskStatus_SucceedsWithValidData_PosttestAction
            // 
            resources.ApplyResources(LogTaskStatus_SucceedsWithValidData_PosttestAction, "LogTaskStatus_SucceedsWithValidData_PosttestAction");
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

        private SqlDatabaseTestActions LogTaskStatus_SucceedsWithValidDataData;
    }
}
