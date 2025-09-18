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
    public class GetAllTasksTests : SqlDatabaseTestClass
    {

        public GetAllTasksTests()
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
        public void GetAllTasks_Returns_Paginated_Tasks()
        {
            SqlDatabaseTestActions testActions = this.GetAllTasks_Returns_Paginated_TasksData;
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
        [TestMethod()]
        public void GetAllTasks_Returns_All_Tasks()
        {
            SqlDatabaseTestActions testActions = this.GetAllTasks_Returns_All_TasksData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }


        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_Paginated_Tasks_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckPaginatedTaskSuccess;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetAllTasksTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_Paginated_Tasks_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_Paginated_Tasks_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_All_Tasks_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_All_Tasks_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllTasks_Returns_All_Tasks_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckReturnsAll;
            this.GetAllTasks_Returns_Paginated_TasksData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.GetAllTasks_Returns_All_TasksData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            GetAllTasks_Returns_Paginated_Tasks_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckPaginatedTaskSuccess = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            GetAllTasks_Returns_Paginated_Tasks_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            GetAllTasks_Returns_Paginated_Tasks_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            GetAllTasks_Returns_All_Tasks_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            GetAllTasks_Returns_All_Tasks_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            GetAllTasks_Returns_All_Tasks_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckReturnsAll = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            // 
            // GetAllTasks_Returns_Paginated_Tasks_TestAction
            // 
            GetAllTasks_Returns_Paginated_Tasks_TestAction.Conditions.Add(CheckPaginatedTaskSuccess);
            resources.ApplyResources(GetAllTasks_Returns_Paginated_Tasks_TestAction, "GetAllTasks_Returns_Paginated_Tasks_TestAction");
            // 
            // CheckPaginatedTaskSuccess
            // 
            CheckPaginatedTaskSuccess.Enabled = true;
            CheckPaginatedTaskSuccess.Name = "CheckPaginatedTaskSuccess";
            resources.ApplyResources(CheckPaginatedTaskSuccess, "CheckPaginatedTaskSuccess");
            CheckPaginatedTaskSuccess.Verbose = false;
            // 
            // GetAllTasks_Returns_Paginated_Tasks_PretestAction
            // 
            resources.ApplyResources(GetAllTasks_Returns_Paginated_Tasks_PretestAction, "GetAllTasks_Returns_Paginated_Tasks_PretestAction");
            // 
            // GetAllTasks_Returns_Paginated_Tasks_PosttestAction
            // 
            resources.ApplyResources(GetAllTasks_Returns_Paginated_Tasks_PosttestAction, "GetAllTasks_Returns_Paginated_Tasks_PosttestAction");
            // 
            // GetAllTasks_Returns_Paginated_TasksData
            // 
            this.GetAllTasks_Returns_Paginated_TasksData.PosttestAction = GetAllTasks_Returns_Paginated_Tasks_PosttestAction;
            this.GetAllTasks_Returns_Paginated_TasksData.PretestAction = GetAllTasks_Returns_Paginated_Tasks_PretestAction;
            this.GetAllTasks_Returns_Paginated_TasksData.TestAction = GetAllTasks_Returns_Paginated_Tasks_TestAction;
            // 
            // GetAllTasks_Returns_All_TasksData
            // 
            this.GetAllTasks_Returns_All_TasksData.PosttestAction = GetAllTasks_Returns_All_Tasks_PosttestAction;
            this.GetAllTasks_Returns_All_TasksData.PretestAction = GetAllTasks_Returns_All_Tasks_PretestAction;
            this.GetAllTasks_Returns_All_TasksData.TestAction = GetAllTasks_Returns_All_Tasks_TestAction;
            // 
            // GetAllTasks_Returns_All_Tasks_TestAction
            // 
            GetAllTasks_Returns_All_Tasks_TestAction.Conditions.Add(CheckReturnsAll);
            resources.ApplyResources(GetAllTasks_Returns_All_Tasks_TestAction, "GetAllTasks_Returns_All_Tasks_TestAction");
            // 
            // GetAllTasks_Returns_All_Tasks_PretestAction
            // 
            resources.ApplyResources(GetAllTasks_Returns_All_Tasks_PretestAction, "GetAllTasks_Returns_All_Tasks_PretestAction");
            // 
            // GetAllTasks_Returns_All_Tasks_PosttestAction
            // 
            resources.ApplyResources(GetAllTasks_Returns_All_Tasks_PosttestAction, "GetAllTasks_Returns_All_Tasks_PosttestAction");
            // 
            // CheckReturnsAll
            // 
            CheckReturnsAll.Enabled = true;
            CheckReturnsAll.Name = "CheckReturnsAll";
            resources.ApplyResources(CheckReturnsAll, "CheckReturnsAll");
            CheckReturnsAll.Verbose = false;
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

        private SqlDatabaseTestActions GetAllTasks_Returns_Paginated_TasksData;
        private SqlDatabaseTestActions GetAllTasks_Returns_All_TasksData;
    }
}
