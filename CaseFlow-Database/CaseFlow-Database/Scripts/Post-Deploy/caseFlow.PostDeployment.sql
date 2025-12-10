/*
Post-Deployment Script for all data and configuration
*/

 :r .\Data\Configurations\caseFlow.ConfigureDatabaseCache.sql
 :r .\Data\StaticData\caseFlow.InsertStatuses.sql

GO

PRINT N'All post-deployment scripts finished.';