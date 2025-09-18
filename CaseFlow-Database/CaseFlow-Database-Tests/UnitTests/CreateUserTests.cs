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
    public class CreateUserTests : SqlDatabaseTestClass
    {
        public CreateUserTests()
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
        public void CreateUser_ThrowsOnDuplicateUser()
        {
            SqlDatabaseTestActions testActions = this.CreateUser_ThrowsOnDuplicateUserData;
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

        [TestMethod()]
        public void CreateUser_SucceedsWithValidData()
        {
            SqlDatabaseTestActions testActions = this.CreateUser_SucceedsWithValidDataData;
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
        [TestMethod()]
        public void CreateUser_CorrectlyGeneratesUsername()
        {
            SqlDatabaseTestActions testActions = this.CreateUser_CorrectlyGeneratesUsernameData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_ThrowsOnDuplicateUser_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckError;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_ThrowsOnDuplicateUser_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_ThrowsOnDuplicateUser_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_SucceedsWithValidData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckCreatedUser;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_SucceedsWithValidData_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_SucceedsWithValidData_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_CorrectlyGeneratesUsername_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckUsernameGeneration;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CreateUser_CorrectlyGeneratesUsername_PosttestAction;
            this.CreateUser_ThrowsOnDuplicateUserData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.CreateUser_SucceedsWithValidDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.CreateUser_CorrectlyGeneratesUsernameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            CreateUser_ThrowsOnDuplicateUser_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckError = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            CreateUser_ThrowsOnDuplicateUser_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateUser_ThrowsOnDuplicateUser_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateUser_SucceedsWithValidData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckCreatedUser = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            CreateUser_SucceedsWithValidData_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateUser_SucceedsWithValidData_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CreateUser_CorrectlyGeneratesUsername_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckUsernameGeneration = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            CreateUser_CorrectlyGeneratesUsername_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // CreateUser_ThrowsOnDuplicateUser_TestAction
            // 
            CreateUser_ThrowsOnDuplicateUser_TestAction.Conditions.Add(CheckError);
            resources.ApplyResources(CreateUser_ThrowsOnDuplicateUser_TestAction, "CreateUser_ThrowsOnDuplicateUser_TestAction");
            // 
            // CheckError
            // 
            CheckError.Enabled = true;
            CheckError.Name = "CheckError";
            resources.ApplyResources(CheckError, "CheckError");
            CheckError.Verbose = false;
            // 
            // CreateUser_ThrowsOnDuplicateUser_PretestAction
            // 
            resources.ApplyResources(CreateUser_ThrowsOnDuplicateUser_PretestAction, "CreateUser_ThrowsOnDuplicateUser_PretestAction");
            // 
            // CreateUser_ThrowsOnDuplicateUser_PosttestAction
            // 
            resources.ApplyResources(CreateUser_ThrowsOnDuplicateUser_PosttestAction, "CreateUser_ThrowsOnDuplicateUser_PosttestAction");
            // 
            // CreateUser_SucceedsWithValidData_TestAction
            // 
            CreateUser_SucceedsWithValidData_TestAction.Conditions.Add(CheckCreatedUser);
            resources.ApplyResources(CreateUser_SucceedsWithValidData_TestAction, "CreateUser_SucceedsWithValidData_TestAction");
            // 
            // CheckCreatedUser
            // 
            CheckCreatedUser.Enabled = true;
            CheckCreatedUser.Name = "CheckCreatedUser";
            resources.ApplyResources(CheckCreatedUser, "CheckCreatedUser");
            CheckCreatedUser.Verbose = false;
            // 
            // CreateUser_SucceedsWithValidData_PosttestAction
            // 
            resources.ApplyResources(CreateUser_SucceedsWithValidData_PosttestAction, "CreateUser_SucceedsWithValidData_PosttestAction");
            // 
            // CreateUser_SucceedsWithValidData_PretestAction
            // 
            resources.ApplyResources(CreateUser_SucceedsWithValidData_PretestAction, "CreateUser_SucceedsWithValidData_PretestAction");
            // 
            // CreateUser_CorrectlyGeneratesUsername_TestAction
            // 
            CreateUser_CorrectlyGeneratesUsername_TestAction.Conditions.Add(CheckUsernameGeneration);
            resources.ApplyResources(CreateUser_CorrectlyGeneratesUsername_TestAction, "CreateUser_CorrectlyGeneratesUsername_TestAction");
            // 
            // CheckUsernameGeneration
            // 
            CheckUsernameGeneration.Enabled = true;
            CheckUsernameGeneration.Name = "CheckUsernameGeneration";
            resources.ApplyResources(CheckUsernameGeneration, "CheckUsernameGeneration");
            CheckUsernameGeneration.Verbose = false;
            // 
            // CreateUser_CorrectlyGeneratesUsername_PosttestAction
            // 
            resources.ApplyResources(CreateUser_CorrectlyGeneratesUsername_PosttestAction, "CreateUser_CorrectlyGeneratesUsername_PosttestAction");
            // 
            // CreateUser_ThrowsOnDuplicateUserData
            // 
            this.CreateUser_ThrowsOnDuplicateUserData.PosttestAction = CreateUser_ThrowsOnDuplicateUser_PosttestAction;
            this.CreateUser_ThrowsOnDuplicateUserData.PretestAction = CreateUser_ThrowsOnDuplicateUser_PretestAction;
            this.CreateUser_ThrowsOnDuplicateUserData.TestAction = CreateUser_ThrowsOnDuplicateUser_TestAction;
            // 
            // CreateUser_SucceedsWithValidDataData
            // 
            this.CreateUser_SucceedsWithValidDataData.PosttestAction = CreateUser_SucceedsWithValidData_PosttestAction;
            this.CreateUser_SucceedsWithValidDataData.PretestAction = CreateUser_SucceedsWithValidData_PretestAction;
            this.CreateUser_SucceedsWithValidDataData.TestAction = CreateUser_SucceedsWithValidData_TestAction;
            // 
            // CreateUser_CorrectlyGeneratesUsernameData
            // 
            this.CreateUser_CorrectlyGeneratesUsernameData.PosttestAction = CreateUser_CorrectlyGeneratesUsername_PosttestAction;
            this.CreateUser_CorrectlyGeneratesUsernameData.PretestAction = null;
            this.CreateUser_CorrectlyGeneratesUsernameData.TestAction = CreateUser_CorrectlyGeneratesUsername_TestAction;
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
        private SqlDatabaseTestActions CreateUser_ThrowsOnDuplicateUserData;
        private SqlDatabaseTestActions CreateUser_SucceedsWithValidDataData;
        private SqlDatabaseTestActions CreateUser_CorrectlyGeneratesUsernameData;
    }
}
