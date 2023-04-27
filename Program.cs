using Microsoft.Data.SqlClient;

///STRUCTURE DU LIEN GOOGLABLE + TRUSTSERVERCERTIFICATE EN DEHORS DE LA PROD
SqlConnection connection = new SqlConnection("Server=localhost;Database=ApprendreCsharp;User Id=sa;Password=Passw0rd*;TrustServerCertificate=True");

connection.Open();

try 
{
    System.Console.WriteLine("Connexion ouverte !");
}
catch (System.Exception)
{
    throw;
}
finally
{
    ///TOUJOURS FERMER APRES USAGE
    connection.Close();
}