<h1>Web Scraping of Buscapé and Mercado Livre with Backend in .NET and Frontend in BootstrapVue</h1>
  
This project consists of a web scraping application that extracts product information from two Brazilian e-commerce websites, Buscapé and Mercado Livre. The backend is developed using .NET in C#, with a connection to SQL Server. The frontend is developed using BootstrapVue.

<h2>Features</h2>

- Users can search for products by selecting the website (Buscapé or Mercado Livre) and category (cell phone, TV, or refrigerator).
- Users can filter their search using the search bar.
- Search results are saved to the SQL Server database.

<h2>Installation</h2>
<h3>Prerequisites</h3>

Visual Studio 2019 or later
SQL Server Management Studio
.NET Core 6

<h3>Instructions</h3>

- Clone the repository to your local machine.
- Open the solution file in Visual Studio.
- Build the solution to restore packages.
- Open the appsettings.json file in the backend project and configure the database connection string.
- Open the Package Manager Console and run the command Update-Database to apply the database migrations.
- Run the backend project.
- Open a terminal and navigate to the frontend project directory.
- Run the command npm install to install dependencies.
- Run the command npm run serve to start the frontend application.
- Open the application in your web browser at the specified URL.

<h3>Usage</h3>

- Select the website you want to search on (Buscapé or Mercado Livre).
- Select the category you want to search in (cell phone, TV, or refrigerator).
- Enter your search query in the search bar.
- Click the search button or press Enter to see the search results.
- You can filter the results using the search bar or by selecting a category.
- The search results are saved to the SQL Server database.

<h3>Future Improvements</h3>

- Implement pagination for search results.
- Improve search algorithm to provide more accurate and relevant results.
- Add more product categories and websites to search.
- Improve the conversion of images of some products.
- Identity the most stable tag for scrap on the Mercado Livre.

