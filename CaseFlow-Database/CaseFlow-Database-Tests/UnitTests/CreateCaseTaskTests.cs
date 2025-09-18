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
    public class CreateCaseTaskTests : SqlDatabaseTestClass
    {

        public CreateCaseTaskTests()
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
        public void CreateCaseTask_SucceedsWithValidData()
        {
            SqlDatabaseTestActions testActions = this.CreateCaseTask_SucceedsWithValidDataData;
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
        public void CreateCaseTask_ThrowOnDuplicateTestCreation()
        {
            SqlDatabaseTestActions testActions = this.CreateCaseTask_ThrowOnDuplicateTestCreationData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateCaseTask_SucceedsWithValidData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckTaskCreation;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCaseTaskTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateCaseTask_SucceedsWithValidData_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheCkDuplicationTaskException;
            this.CreateCaseTask_SucceedsWithValidDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.CreateCaseTask_ThrowOnDuplicateTestCreationData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            CreateCaseTask_SucceedsWithValidData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckTaskCreation = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            CreateCaseTask_SucceedsWithValidData_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheCkDuplicationTaskException = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            // 
            // CreateCaseTask_SucceedsWithValidData_TestAction
            // 
            CreateCaseTask_SucceedsWithValidData_TestAction.Conditions.Add(CheckTaskCreation);
            resources.ApplyResources(CreateCaseTask_SucceedsWithValidData_TestAction, "CreateCaseTask_SucceedsWithValidData_TestAction");
            // 
            // CheckTaskCreation
            // 
            CheckTaskCreation.Enabled = true;
            CheckTaskCreation.Name = "CheckTaskCreation";
            resources.ApplyResources(CheckTaskCreation, "CheckTaskCreation");
            CheckTaskCreation.Verbose = false;
            // 
            // CreateCaseTask_SucceedsWithValidData_PosttestAction
            // 
            resources.ApplyResources(CreateCaseTask_SucceedsWithValidData_PosttestAction, "CreateCaseTask_SucceedsWithValidData_PosttestAction");
            // 
            // CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction
            // 
            CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction.Conditions.Add(CheCkDuplicationTaskException);
            resources.ApplyResources(CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction, "CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction");
            // 
            // CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction
            // 
            resources.ApplyResources(CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction, "CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction");
            // 
            // CreateCaseTask_SucceedsWithValidDataData
            // 
            this.CreateCaseTask_SucceedsWithValidDataData.PosttestAction = CreateCaseTask_SucceedsWithValidData_PosttestAction;
            this.CreateCaseTask_SucceedsWithValidDataData.PretestAction = null;
            this.CreateCaseTask_SucceedsWithValidDataData.TestAction = CreateCaseTask_SucceedsWithValidData_TestAction;
            // 
            // CreateCaseTask_ThrowOnDuplicateTestCreationData
            // 
            this.CreateCaseTask_ThrowOnDuplicateTestCreationData.PosttestAction = CreateCaseTask_ThrowOnDuplicateTestCreation_PosttestAction;
            this.CreateCaseTask_ThrowOnDuplicateTestCreationData.PretestAction = null;
            this.CreateCaseTask_ThrowOnDuplicateTestCreationData.TestAction = CreateCaseTask_ThrowOnDuplicateTestCreation_TestAction;
            // 
            // CheCkDuplicationTaskException
            // 
            CheCkDuplicationTaskException.Enabled = true;
            CheCkDuplicationTaskException.Name = "CheCkDuplicationTaskException";
            resources.ApplyResources(CheCkDuplicationTaskException, "CheCkDuplicationTaskException");
            CheCkDuplicationTaskException.Verbose = false;
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

        private SqlDatabaseTestActions CreateCaseTask_SucceedsWithValidDataData;
        private SqlDatabaseTestActions CreateCaseTask_ThrowOnDuplicateTestCreationData;
    }
}
