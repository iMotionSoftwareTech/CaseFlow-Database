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
    public class CreateRoleTests : SqlDatabaseTestClass
    {

        public CreateRoleTests()
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
        public void CreateRole_SuccessfulCreation_Test()
        {
            SqlDatabaseTestActions testActions = this.CreateRole_SuccessfulCreation_TestData;
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
        public void CreateRole_Throw_OnDuplicationCreation_Test()
        {
            SqlDatabaseTestActions testActions = this.CreateRole_Throw_OnDuplicationCreation_TestData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateRole_SuccessfulCreation_Test_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckRoleCreation;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoleTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateRole_SuccessfulCreation_Test_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateRole_Throw_OnDuplicationCreation_Test_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateRole_Throw_OnDuplicationCreation_Test_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckDuplicateRoleError;
            this.CreateRole_SuccessfulCreation_TestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.CreateRole_Throw_OnDuplicationCreation_TestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            CreateRole_SuccessfulCreation_Test_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckRoleCreation = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            CreateRole_SuccessfulCreation_Test_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateRole_Throw_OnDuplicationCreation_Test_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateRole_Throw_OnDuplicationCreation_Test_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckDuplicateRoleError = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            // 
            // CreateRole_SuccessfulCreation_Test_TestAction
            // 
            CreateRole_SuccessfulCreation_Test_TestAction.Conditions.Add(CheckRoleCreation);
            resources.ApplyResources(CreateRole_SuccessfulCreation_Test_TestAction, "CreateRole_SuccessfulCreation_Test_TestAction");
            // 
            // CheckRoleCreation
            // 
            CheckRoleCreation.Enabled = true;
            CheckRoleCreation.Name = "CheckRoleCreation";
            resources.ApplyResources(CheckRoleCreation, "CheckRoleCreation");
            CheckRoleCreation.Verbose = false;
            // 
            // CreateRole_SuccessfulCreation_Test_PosttestAction
            // 
            resources.ApplyResources(CreateRole_SuccessfulCreation_Test_PosttestAction, "CreateRole_SuccessfulCreation_Test_PosttestAction");
            // 
            // CreateRole_Throw_OnDuplicationCreation_Test_TestAction
            // 
            CreateRole_Throw_OnDuplicationCreation_Test_TestAction.Conditions.Add(CheckDuplicateRoleError);
            resources.ApplyResources(CreateRole_Throw_OnDuplicationCreation_Test_TestAction, "CreateRole_Throw_OnDuplicationCreation_Test_TestAction");
            // 
            // CreateRole_Throw_OnDuplicationCreation_Test_PretestAction
            // 
            resources.ApplyResources(CreateRole_Throw_OnDuplicationCreation_Test_PretestAction, "CreateRole_Throw_OnDuplicationCreation_Test_PretestAction");
            // 
            // CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction
            // 
            resources.ApplyResources(CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction, "CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction");
            // 
            // CreateRole_SuccessfulCreation_TestData
            // 
            this.CreateRole_SuccessfulCreation_TestData.PosttestAction = CreateRole_SuccessfulCreation_Test_PosttestAction;
            this.CreateRole_SuccessfulCreation_TestData.PretestAction = null;
            this.CreateRole_SuccessfulCreation_TestData.TestAction = CreateRole_SuccessfulCreation_Test_TestAction;
            // 
            // CreateRole_Throw_OnDuplicationCreation_TestData
            // 
            this.CreateRole_Throw_OnDuplicationCreation_TestData.PosttestAction = CreateRole_Throw_OnDuplicationCreation_Test_PosttestAction;
            this.CreateRole_Throw_OnDuplicationCreation_TestData.PretestAction = CreateRole_Throw_OnDuplicationCreation_Test_PretestAction;
            this.CreateRole_Throw_OnDuplicationCreation_TestData.TestAction = CreateRole_Throw_OnDuplicationCreation_Test_TestAction;
            // 
            // CheckDuplicateRoleError
            // 
            CheckDuplicateRoleError.Enabled = true;
            CheckDuplicateRoleError.Name = "CheckDuplicateRoleError";
            resources.ApplyResources(CheckDuplicateRoleError, "CheckDuplicateRoleError");
            CheckDuplicateRoleError.Verbose = false;
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

        private SqlDatabaseTestActions CreateRole_SuccessfulCreation_TestData;
        private SqlDatabaseTestActions CreateRole_Throw_OnDuplicationCreation_TestData;
    }
}
