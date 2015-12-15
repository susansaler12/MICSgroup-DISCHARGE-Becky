CREATE TABLE [dbo].[Table]
(
	[patient_id] INT  NOT NULL PRIMARY KEY, 
    [first_name] NVARCHAR(50) NOT NULL, 
    [last_name] NVARCHAR(50) NOT NULL, 
    [doctor_id] INT NOT NULL, 
    [admit_time] TIMESTAMP NOT NULL, 
    [discharge] TIMESTAMP NULL, 
    [birthday] DATE NOT NULL
)
