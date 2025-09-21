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
    public class GetAllRolesTests : SqlDatabaseTestClass
    {

        public GetAllRolesTests()
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
        public void GetAllRoles_Returns_All_Roles_Test()
        {
            SqlDatabaseTestActions testActions = this.GetAllRoles_Returns_All_Roles_TestData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction GetAllRoles_Returns_All_Roles_Test_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition CheckAllRolesRetreived;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetAllRolesTests));
            this.GetAllRoles_Returns_All_Roles_TestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            GetAllRoles_Returns_All_Roles_Test_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckAllRolesRetreived = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            // 
            // GetAllRoles_Returns_All_Roles_TestData
            // 
            this.GetAllRoles_Returns_All_Roles_TestData.PosttestAction = null;
            this.GetAllRoles_Returns_All_Roles_TestData.PretestAction = null;
            this.GetAllRoles_Returns_All_Roles_TestData.TestAction = GetAllRoles_Returns_All_Roles_Test_TestAction;
            // 
            // GetAllRoles_Returns_All_Roles_Test_TestAction
            // 
            GetAllRoles_Returns_All_Roles_Test_TestAction.Conditions.Add(CheckAllRolesRetreived);
            resources.ApplyResources(GetAllRoles_Returns_All_Roles_Test_TestAction, "GetAllRoles_Returns_All_Roles_Test_TestAction");
            // 
            // CheckAllRolesRetreived
            // 
            CheckAllRolesRetreived.Enabled = true;
            CheckAllRolesRetreived.Name = "CheckAllRolesRetreived";
            resources.ApplyResources(CheckAllRolesRetreived, "CheckAllRolesRetreived");
            CheckAllRolesRetreived.Verbose = false;
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

        private SqlDatabaseTestActions GetAllRoles_Returns_All_Roles_TestData;
    }
}
