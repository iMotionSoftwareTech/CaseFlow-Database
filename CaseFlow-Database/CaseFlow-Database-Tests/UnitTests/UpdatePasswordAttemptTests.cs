using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace CaseFlow_Database_Tests.UnitTests
{
    [TestClass()]
    public class UpdatePasswordAttemptTests : SqlDatabaseTestClass
    {

        public UpdatePasswordAttemptTests()
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
        public void UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test()
        {
            SqlDatabaseTestActions testActions = this.UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckPasswordAttempt;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePasswordAttemptTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction;
            this.UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckPasswordAttempt = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction
            // 
            UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction.Conditions.Add(CheckPasswordAttempt);
            resources.ApplyResources(UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction, "UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction");
            // 
            // CheckPasswordAttempt
            // 
            CheckPasswordAttempt.Enabled = true;
            CheckPasswordAttempt.Name = "CheckPasswordAttempt";
            resources.ApplyResources(CheckPasswordAttempt, "CheckPasswordAttempt");
            CheckPasswordAttempt.Verbose = false;
            // 
            // UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction
            // 
            resources.ApplyResources(UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction, "UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction");
            // 
            // UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData
            // 
            this.UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData.PosttestAction = UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_PosttestAction;
            this.UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData.PretestAction = null;
            this.UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData.TestAction = UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_Test_TestAction;
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

        private SqlDatabaseTestActions UpdatePasswordAttemptTests_SuccesfullyUpdatePassword_TestData;
    }
}
