SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Vytvoření tabulky Requests
CREATE TABLE [dbo].[Requests](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Title] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NULL,
    [Priority] [int] NOT NULL,
    [Category] [nvarchar](max) NULL
    
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Primární klíč
ALTER TABLE [dbo].[Requests] ADD CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (
    PAD_INDEX = OFF, 
    STATISTICS_NORECOMPUTE = OFF, 
    SORT_IN_TEMPDB = OFF, 
    IGNORE_DUP_KEY = OFF, 
    ONLINE = OFF, 
    ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON, 
    OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
) ON [PRIMARY]
GO

-- Vložení testovacích dat
INSERT INTO [dbo].[Requests] (Title, Description, Priority, Category, CreatedAt, UpdatedAt)
VALUES 
('Nadpis-test', 'popis', 0, 'HR', '2025-09-09T14:25:34.995108', '2025-09-09T14:25:34.995109'),
('Nadpis-2', 'popis-test', 2, 'IT-Support', '2025-09-09T14:26:23.491243', '2025-09-09T14:26:23.491243'),
('Nadpis-3', 'popis-test3', 1, 'IT-Support', '2025-09-09T14:26:50.561107', '2025-09-09T14:26:50.561107'),
('Nadpis-4', 'popis-test4', 2, 'HR', '2025-09-09T14:27:25.203684', '2025-09-09T14:27:25.203684'),
('string', 'string', 0, 'string', '2025-09-09T14:28:01.692960', '2025-09-09T14:28:23.935563'),
('Test v SQL', 'Popis v SQL', 2, 'HR', '2025-09-10T06:55:46.501331', '2025-09-10T06:55:46.501331');
GO
