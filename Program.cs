using System.Data;
using Microsoft.Data.SqlClient;


///STRUCTURE DU LIEN GOOGLABLE + TRUSTSERVERCERTIFICATE EN DEHORS DE LA PROD
SqlConnection connection = new SqlConnection("Server=localhost;Database=ApprendreCsharp;User Id=sa;Password=Passw0rd*;TrustServerCertificate=True");

connection.Open();

try 
{
    System.Console.WriteLine("Connexion ouverte !");

    /*///1 - CREATE
    SqlCommand command = connection.CreateCommand();
    string? nom = "";
    string? prenom = "";

    while (string.IsNullOrWhiteSpace(prenom)) 
    {
        System.Console.WriteLine("Veuillez saisir votre prénom :");
        prenom = Console.ReadLine();
    }
    
    while (string.IsNullOrWhiteSpace(nom)) 
    {
        System.Console.WriteLine("Veuillez saisir votre nom :");
        nom = Console.ReadLine();
    }

    command.CommandText = "INSERT INTO Personnes(Nom, Prenom) VALUES (@Nom, @Prenom)";

    ///PROTEGE CONTRE LES INJECTIONS SQL AVEC DES PARAMS (ADD, ADDRANGE, ADDWITHVALUE)
    SqlParameter nomParam = new SqlParameter
    {
        DbType = System.Data.DbType.String,
        ParameterName = "@Nom",
        Value = nom
    };
    SqlParameter prenomParam = new SqlParameter
    {
        DbType = System.Data.DbType.String,
        ParameterName = "@Prenom",
        Value = prenom
    };
    command.Parameters.AddRange(new[] { nomParam, prenomParam});


    ///COMMANDE QUI NE RETOURNE PAS DE VALEUR
    var result = command.ExecuteNonQuery();

    if(result > 0)
    {
        System.Console.WriteLine("Insertion effectuée avec succès !");
    } */

    ///2 - READ
    SqlCommand command = new SqlCommand(
        "SELECT * FROM Personnes",
        connection
        );
    
    ///COMMANDE QUI RETOURNE UNE INSTANCE DE SQLDATAREADER
    /* SqlDataReader reader = command.ExecuteReader();
    while(reader.Read() == true)
    {
        var nom = reader.GetString(reader.GetOrdinal("Nom"));
        var prenom = reader.GetString(reader.GetOrdinal("Prenom"));
        System.Console.WriteLine($"{prenom} {nom}");
    } */

    ///3 - DATATABLES

    ///DECLARE TABLE
    DataTable table = new DataTable("Personnes");

    ///COLONNES
    DataColumn id = new DataColumn("Id", typeof(int));
    DataColumn nom = new DataColumn("Nom", typeof(string));
    DataColumn prenom = new DataColumn("Prenom", typeof(string));
    table.Columns.AddRange(new[] { id, nom, prenom });
    ///PRIMARY KEY
    table.PrimaryKey = new[] { id };

    ///INSTANCIE SQLDATAADAPTER SUR LA SQLCOMMAND ECRITE PLUS HAUT
    SqlDataAdapter adapter = new SqlDataAdapter(command);
    ///STOCKE DANS LA TABLE EN MEMOIRE
    adapter.Fill(table);

    ///POSSIBLE DE VERIFIER AVEC DEBUGGER + POINT D'ARRET
    


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


