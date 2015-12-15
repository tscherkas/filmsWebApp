RESTORE DATABASE movies
FROM DISK = 'C:\Users\tscherkas\Downloads\movies_mssql\movies.bak'
WITH MOVE 'movies' to 'C:\Users\tscherkas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\movies.mdf',
MOVE 'movies_log' to 'C:\Users\tscherkas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\movies_log.ldf',
REPLACE