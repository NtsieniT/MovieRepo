TO RUN APPLICATION

1. MAKE SURE DB CONNECTION STRING IS CHANGED TO POINT TO LOCAL INSTANCE ON THE appsettings.json ON THE "Movie.API" AND "Movie.Data"
AND ALSO ON THE "MovieDataContext" OnConfiguring METHOD.

Install dotnet tool install --global dotnet-ef 

2.
//ADD MIGRATION
dotnet ef migrations add -p "C:\Users\NtsieniTshikhakhisa\Downloads\New folder\MovieApp-main\MovieApp-main\Movie.API\src\Movie.Data" Initial  

3.
//UPDATE DATABASE
dotnet ef database update -p "C:\Users\NtsieniTshikhakhisa\Downloads\New folder\MovieApp-main\Movie-main\Movie.API\src\Movie.Data" -c MovieDataContext

4. PROGRAM.CS WILL SEED TYPES INITIALLY IF NO TYPES ARE FOUND ON THE DATABASE
	- TYPES FILE READ IS FOUND ON Movie.Data\SeedData FOLDER. YOU CAN ADD MORE TYPES BEFORE RUNNING THE APPLICATION
	
5. START APPLICATION API src\Movie.API


6. FOR CLIENT, OPEN SOLUTION AND INSTALL PACKAGES USING NPM INSTALL COMMAND

7. RUN CLIENT USING NG SERVE




