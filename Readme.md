# Ping pong tournament management app

A C# WPF app for managing 8 player ping-pong tournaments.

## Getting Started

Clone the project on the disk with the usual git clone.

### Prerequisites

You need to have Microsoft Visual Studio installed, I use the 2017 version.
You need to have Microsoft SQL Server installed, favorably also the Management Studio, to run the script, and you can also see the database diagram there.

### Installing

First, open MS SQL Server Management Studio, set up your connection and open the file "pingpongDBscript.sql" in it (you can also drag and drop).
Click "Execute".
Your database should have been successfully created, it is called 'pingpong'.

```
pingpong
```

Open the project solution in Visual Studio.
From the Tools menu, open "Connect to Database".
In the 'Server name' field paste the server name you copied.
From the Select database dropdown menu, select the 'pingpong' database.
In the properties of the connection, you can find the field "Connection string", copy this.

```
ex: Data Source=DESKTOP-R95RP8R;Initial Catalog=pingpong;Integrated Security=True
```

Open the file DbConnection.cs from the Dao project and replace the value of the field _dbConnectionString with your own.
Save the file.

## Running the tests

From Visual Studio, Test menu -> Run -> Run all tests.

### Break down into end to end tests

Most of them test the database connection, executing queries and the data access objects.

## Authors

* **Gyarmathy Timea** 

## License

This project is licensed under my license, I made it for a school homework but it is pretty awesome so use it as you wish.