﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from dbo.[User]) /*if there is not any rows this wont work*/
begin
    insert into dbo.[User] (FirstName, LastName)
    values ('John', 'Doe'), ('Jane', 'Smith'), ('Alice', 'Johnson'), ('Mary', 'Jones');

end